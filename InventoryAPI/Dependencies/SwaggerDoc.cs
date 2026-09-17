using Microsoft.OpenApi.Models;

namespace InventoryAPI.Dependencies
{
    public static class SwaggerDoc
    {
        public static void SwaggerDocumentationDI(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Inventory API",
                    Version = "v1",
                    Description = "API para la gestión de inventario.",
                    Contact = new OpenApiContact
                    {
                        Name = "Ricardo Cárdenas",
                        Email = "ricardex_21@outlook.com"
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Format: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                options.EnableAnnotations();

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "InventoryAPI.xml"));                
            });           
        }
    }
}

