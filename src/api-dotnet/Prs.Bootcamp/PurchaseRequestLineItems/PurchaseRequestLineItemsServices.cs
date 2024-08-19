using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public static class PurchaseRequestLineItemsServices
{
    public static void AddPurchaseRequestLineItemsServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IQueryHandler<GetPurchaseRequestLineItemQuery, PurchaseRequestLineItem?>, GetPurchaseRequestLineItemQueryHandler>();
        _ = services.AddScoped<ICommandHandler<CreatePurchaseRequestLineItemCommand>, CreatePurchaseRequestLineItemCommandHandler>();
        _ = services.AddScoped<ICommandHandler<UpdatePurchaseRequestLineItemCommand>, UpdatePurchaseRequestLineItemCommandHandler>();
        _ = services.AddScoped<ICommandHandler<DeletePurchaseRequestLineItemCommand>, DeletePurchaseRequestLineItemCommandHandler>();
    }
}
