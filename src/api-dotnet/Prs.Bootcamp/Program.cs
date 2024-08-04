using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
    .UseStaticFiles()
    .UseRouting();

    app.Run();
