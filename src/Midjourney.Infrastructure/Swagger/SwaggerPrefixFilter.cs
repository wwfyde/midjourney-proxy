using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Midjourney.Infrastructure.Swagger
{
    public class SwaggerPrefixFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add($"/midjourney{path.Key}", path.Value);
            }
            swaggerDoc.Paths = paths;
        }
    }
}