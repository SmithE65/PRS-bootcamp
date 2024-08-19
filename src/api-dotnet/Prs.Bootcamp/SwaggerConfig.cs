using Microsoft.OpenApi.Models;

namespace Prs.Bootcamp;

public static class SwaggerConfig
{
    public static void AddSwagger(this IServiceCollection services)
    {
        _ = services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "PrsApi", Version = "v1" });

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("http://localhost:8080/realms/bootcamp/protocol/openid-connect/auth"),
                        TokenUrl = new Uri("http://localhost:8080/realms/bootcamp/protocol/openid-connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { "openid", "OpenID Connect scope" },
                            { "profile", "Profile scope" },
                            { "email", "Email scope" }
                        }
                    }
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        }
                    },
                    ["openid", "profile", "email"]
                }
            });
        });
    }

    public static void AddSwaggerUI(this WebApplication app)
    {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrsApi v1");
            c.OAuthClientId("prs-spa");
            c.OAuthAppName("PRS");
            c.OAuthUsePkce();
        });
    }
}
