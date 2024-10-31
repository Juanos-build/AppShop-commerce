using AppShop.Models.Context.Model;
using AppShop.Models.Entities;
using AppShop.Server.GraphQL.Mutation;
using AppShop.Server.GraphQL.Query;
using AppShop.Server.GraphQL.Type;
using AppShop.Services.Helpers.Extension;
using AppShop.Services.Helpers.Settings;
using AppShop.Services.Interfaces;
using AppShop.Services.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppShop.Server.Extension
{
    public static class ExtensionServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            MapperBootstrapper.Configure();

            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = c =>
                {
                    var errors = string.Join('|', c.ModelState.Values.Where(v => v.Errors.Count > 0)
                      .SelectMany(v => v.Errors)
                      .Select(v => v.ErrorMessage));

                    var bad = new ResponseProblem
                    {
                        Title = "One or more request errors occurred",
                        Status = StatusCodes.Status400BadRequest,
                        StatusMessage = errors
                    }.Bad();
                    return new BadRequestObjectResult(bad);
                };
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials();
            }));

            //Database Context
            services.AddDbContextPool<DataContext>(options =>
            {
                options.UseSqlServer(AppSettings.Settings.Connection);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddGraphQLServer()
                .AddQueryType<ProductQueries>()
                .AddMutationType<OrderMutation>()
                .AddType<ProductType>()
                .AddFiltering()
                .AddProjections()
                .AddSorting();

            return services;
        }

        public static void ConfigureHandler(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelsExpandDepth(-1);
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");
            app.MapGraphQL();
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ResponseProblem
                        {
                            StatusCode = context.Response.StatusCode,
                            StatusMessage = contextFeature.Error.ToString()

                        }.ToString());
                    }
                });
            });
        }
    }
}
