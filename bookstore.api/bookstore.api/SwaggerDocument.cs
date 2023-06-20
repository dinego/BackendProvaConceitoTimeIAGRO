using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace bookstore.api
{
    public class SwaggerSummaryDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var pathItem in swaggerDoc.Paths.Values)
            {
                foreach (var operation in pathItem.Operations)
                {
                    if (!string.IsNullOrEmpty(operation.Value.Summary))
                    {
                        operation.Value.Description = operation.Value.Summary;
                        operation.Value.Summary = null;
                    }
                }
            }
        }
    }
}
