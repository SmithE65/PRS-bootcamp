using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public static class PurchaseRequestServices
{
    public static void AddPurchaseRequestServices(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetPurchaseRequestsQuery, IEnumerable<PurchaseRequest>>, GetPurchaseRequestsQueryHandler>();
        services.AddScoped<IQueryHandler<GetPurchaseRequestQuery, PurchaseRequest?>, GetPurchaseRequestQueryHandler>();
        services.AddScoped<ICommandHandler<CreatePurchaseRequestCommand>, CreatePurchaseRequestCommandHandler>();
        services.AddScoped<ICommandHandler<UpdatePurchaseRequestCommand>, UpdatePurchaseRequestCommandHandler>();
        services.AddScoped<ICommandHandler<DeletePurchaseRequestCommand>, DeletePurchaseRequestCommandHandler>();
        services.AddScoped<ICommandHandler<ApprovePurchaseRequestCommand>, ApprovePurchaseRequestCommandHandler>();
        services.AddScoped<ICommandHandler<RejectPurchaseRequestCommand>, RejectPurchaseRequestCommandHandler>();
        services.AddScoped<IQueryHandler<GetPurchaseRequestsForReviewQuery, IEnumerable<PurchaseRequest>>, GetPurchaseRequestsForReviewQueryHandler>();
        services.AddScoped<ICommandHandler<ReadyForReviewCommand>, ReadyForReviewCommandHandler>();
    }
}
