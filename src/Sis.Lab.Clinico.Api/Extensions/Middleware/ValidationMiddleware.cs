using Sis.Lab.Clinico.Application.UseCase.Common.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using ValidationException = Sis.Lab.Clinico.Application.UseCase.Common.Exceptions.ValidationException;

namespace Sis.Lab.Clinico.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = "Errores de Validación",
                    Errors = ex.Errors
                });
            }
        }
    }
}
