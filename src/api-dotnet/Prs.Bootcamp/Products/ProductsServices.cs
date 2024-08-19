using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

public static class ProductsServices
{
    public static void AddProductsServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IQueryHandler<GetProductsQuery, IEnumerable<Product>>, GetProductsQueryHandler>();
        _ = services.AddScoped<IQueryHandler<GetProductQuery, Product?>, GetProductQueryHandler>();
        _ = services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
        _ = services.AddScoped<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
        _ = services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
    }
}
