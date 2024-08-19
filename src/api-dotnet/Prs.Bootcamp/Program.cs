using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp;
using Prs.Bootcamp.Authentication;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Products;
using Prs.Bootcamp.PurchaseRequestLineItems;
using Prs.Bootcamp.PurchaseRequests;
using Prs.Bootcamp.Vendors;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PrsDbConnection")
    ?? throw new InvalidOperationException("Missing connection string 'PrsDbConnection' in appsettings.json");

builder.Services.AddPrsDbContext(connectionString);
builder.Services.AddKeyCloakAuthentication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddVendorsServices();
builder.Services.AddProductsServices();
builder.Services.AddPurchaseRequestServices();
builder.Services.AddPurchaseRequestLineItemsServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AddSwaggerUI();
}
else
{
    _ = app.UseHsts();
}

_ = app.UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();
