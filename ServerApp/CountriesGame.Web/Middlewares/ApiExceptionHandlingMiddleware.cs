using System;
using System.Text.Json;
using System.Threading.Tasks;
using CountriesGame.Bll.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountriesGame.Web.Middlewares
{
    public class ApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            var problemDetails = GetProblemDetails(ex);
            
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        private ProblemDetails GetProblemDetails(Exception ex)
        {
            var problemDetails = new ProblemDetails();

            switch (ex)
            {
                case EntityNotFoundException entityNotFoundException:
                    problemDetails.Title = "Error Quering the Data";
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    break;
                case IdentityException identityException:
                    problemDetails.Title = "Error Using Identity";
                    problemDetails.Extensions.Add("errors", identityException.IdentityErrors);
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    break;
                case DublicateFoundException dublicateFoundException:
                    problemDetails.Title = "Submitted quiz contains dublicate question(s) or/and option(s)";
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    break;
                default:
                    problemDetails.Title = "Internal Server Error";
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    break;
            }

            return problemDetails;
        }
    }
}