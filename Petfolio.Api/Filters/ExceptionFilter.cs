using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Petfolio.Communication.Responses;
using Petfolio.Exception.ExceptionsBase;

namespace Petfolio.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is PetfolioException)
            {
                HandleProjectExeception(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }


        private void HandleProjectExeception(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationsException)
            {
                var ex = (ErrorOnValidationsException)context.Exception;
                var erroMessage = new ResponseErrosJson(ex.ErrorMensagens);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(erroMessage);

            }
            else
            { //TODO: Temporario
                var erroMessage = new ResponseErrosJson(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(erroMessage);
            }
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            var erroMessage = new ResponseErrosJson("Unknown error");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(erroMessage);


        }
    }
}