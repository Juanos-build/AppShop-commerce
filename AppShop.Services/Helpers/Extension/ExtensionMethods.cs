using AppShop.Models.Entities;
using System.Net;

namespace AppShop.Services.Helpers.Extension
{
    public static class ExtensionMethods
    {
        public static Response<T> Success<T>(this Response<T> response, Response<T> result = null)
        {
            ArgumentNullException.ThrowIfNull(response);

            response.Result = result != null ? result.Result : response.Result != null ? response.Result : default;
            response.HttpStatusCode = HttpStatusCode.OK;
            response.IsSuccess = true;
            return response;
        }

        public static Response<T> Error<T>(this Response<T> response, ResultException ex)
        {
            response.StatusMessage = $"{ex.Detail} {ex.Message}";
            return response;
        }

        public static Response<T> Exception<T>(this Response<T> response, Exception ex)
        {
            response.StatusMessage = $"{ex.Message} {ex.InnerException}";
            return response;
        }

        public static ResponseProblem Bad<T>(this ResponseProblem error, Response<T> response)
        {
            error.StatusMessage = response.StatusMessage;
            return error;
        }

        public static ResponseProblem Bad(this ResponseProblem error)
        {
            return error;
        }
    }
}
