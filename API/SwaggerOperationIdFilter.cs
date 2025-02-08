using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API;

[UsedImplicitly]
public class SwaggerOperationIdFilter : IOperationFilter
{
    private readonly Dictionary<string, string> _swaggerOperationIds = new();

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (!(context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)) return;

        if (_swaggerOperationIds.ContainsKey(controllerActionDescriptor.Id))
        {
            operation.OperationId = _swaggerOperationIds[controllerActionDescriptor.Id];
        }
        else
        {
            var operationIdBaseName =
                $"{controllerActionDescriptor.ControllerName}_{controllerActionDescriptor.ActionName}";
            var operationId = operationIdBaseName;
            var suffix = 2;
            while (_swaggerOperationIds.Values.Contains(operationId)) operationId = $"{operationIdBaseName}{suffix++}";

            _swaggerOperationIds[controllerActionDescriptor.Id] = operationId;
            operation.OperationId = operationId;
        }
    }
}