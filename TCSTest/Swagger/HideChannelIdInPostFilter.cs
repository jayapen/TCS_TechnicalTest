
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TCSTest.Models.DTO;

namespace TCSTest.Swagger
{
    public class HideChannelIdInPostFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.Name == "ChannelDto")
            {
                if (schema.Properties.ContainsKey("channelId"))
                {
                    schema.Properties.Remove("channelId");
                }
            }
        }
    }
}