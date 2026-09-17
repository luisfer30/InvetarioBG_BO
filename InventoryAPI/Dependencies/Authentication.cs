using InventoryModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryAPI.Dependencies
{
    public static class Authentication
    {
        public static void AuthenticationDI(this IServiceCollection services, IConfiguration configuration)
        {
            var Issuer = configuration["JWT:Issuer"];
            var Audience = configuration["JWT:Audience"];
            var secretKey = Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]!);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsJsonAsync(new Response<ErrorModel>
                        {
                            Success = false,
                            Message = "Debe autenticarse para acceder a este recurso.",
                            Data = new ErrorModel()
                            {
                                StatusCode = StatusCodes.Status401Unauthorized,
                                TraceId = string.Empty
                            }
                        });
                    }
                };
            });
        }
    }
}
