using AppShop.Server.Extension;
using AppShop.Services.Helpers.Settings;

var builder = WebApplication.CreateBuilder(args);

AppSettings.Settings = builder.Configuration.GetSection("appSettings").Get<AppSettings>();

builder.Services.ConfigureServices();

var app = builder.Build();
app.ConfigureHandler();
app.Run();
