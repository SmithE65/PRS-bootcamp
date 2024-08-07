using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrsDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("PrsDbConnection")
        ?? throw new InvalidOperationException("Missing connection string 'PrsDbConnection' in appsettings.json");

    _ = opt.UseSqlServer(connectionString,
        sqlOpts =>
        {
            _ = sqlOpts.EnableRetryOnFailure();
            _ = sqlOpts.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
        });
});

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:8080/auth/realms/bootcamp";
        options.MetadataAddress = "http://localhost:8080/auth/realms/bootcamp/.well-known/openid-configuration";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new()
        {
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role,
            ValidateIssuer = true,
            ValidIssuers = ["http://localhost:8080/auth/realms/bootcamp"],
            ValidateAudience = true,
            ValidAudiences = ["bootcamp-api"]
        };
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PrsApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseSwagger()
    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrsApi v1"))
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

app.Run();
