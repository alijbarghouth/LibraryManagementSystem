using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filter;

public sealed class ModelStateFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context
        , ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
            return;
        }

        await next();
    }
}
