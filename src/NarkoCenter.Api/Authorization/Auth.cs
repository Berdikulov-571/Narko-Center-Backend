using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace NarkoCenter.Api.Authorization
{
    public static class Auth
    {
        public static IServiceCollection AddAutorization(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "Issuer",
                        ValidateAudience = true,
                        ValidAudience = "Audience",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mana-shu-security-key"))
                    };
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AuthDemo",
                    Description = "Auth Demo Description"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Bearer Authentication",
                    Type = SecuritySchemeType.Http
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string> ()
                    }

                });
            });

            return services;
        }
    }
}