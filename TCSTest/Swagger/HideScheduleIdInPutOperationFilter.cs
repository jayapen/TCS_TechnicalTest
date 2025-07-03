using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TCSTest.Models;

namespace TCSTest.Swagger
{
    /// <summary>
    /// Removes 'channelId' and 'contentId' from the request body schema 
    /// in PUT operations for Schedule DTO, without affecting POST schema.
    /// </summary>
    public class HideScheduleIdInPutOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod?.ToUpper() != "PUT")
                return;

            // Ensure we're targeting the Schedule DTO
            var usesScheduleDto = context.ApiDescription.ParameterDescriptions
                .Any(p => p.Type == typeof(Schedule));

            if (!usesScheduleDto)
                return;

            if (operation.RequestBody?.Content.TryGetValue("application/json", out var mediaType) != true)
                return;

            var schema = mediaType.Schema;

            // If schema is a reference to a shared component, clone it first to avoid global mutation
            if (schema?.Reference != null)
            {
                var refId = schema.Reference.Id;

                if (context.SchemaRepository.Schemas.TryGetValue(refId, out var referencedSchema))
                {
                    var clonedSchema = CloneSchema(referencedSchema);
                    RemoveProperties(clonedSchema);
                    mediaType.Schema = clonedSchema;
                }
            }
            else
            {
                RemoveProperties(schema);
            }
        }

        private void RemoveProperties(OpenApiSchema schema)
        {
            if (schema?.Properties == null) return;

            schema.Properties.Remove("channelId");
            schema.Properties.Remove("contentId");
        }

        private OpenApiSchema CloneSchema(OpenApiSchema original)
        {
            return new OpenApiSchema
            {
                Type = original.Type,
                Format = original.Format,
                Title = original.Title,
                Description = original.Description,
                Nullable = original.Nullable,
                Example = original.Example,
                ExternalDocs = original.ExternalDocs,
                Deprecated = original.Deprecated,
                Default = original.Default,
                ReadOnly = original.ReadOnly,
                WriteOnly = original.WriteOnly,
                Properties = new Dictionary<string, OpenApiSchema>(original.Properties),
                Required = new SortedSet<string>(original.Required),
                AllOf = original.AllOf.ToList(),
                OneOf = original.OneOf.ToList(),
                AnyOf = original.AnyOf.ToList(),
                Items = original.Items,
                AdditionalPropertiesAllowed = original.AdditionalPropertiesAllowed,
                AdditionalProperties = original.AdditionalProperties,
                Enum = original.Enum.ToList()
            };
        }
    }
}
