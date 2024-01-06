using MassTransit;
using MassTransit.Courier.Contracts;

namespace Masstransit.Common;

public static class ConsumeContextExtensions
{
    public static Guid? GetRequestId(this ConsumeContext<RoutingSlipCompleted> context)
    {
        return context.GetVariable<Guid>(nameof(ConsumeContext.RequestId));
    }

    public static Uri? GetResponseAddress(this ConsumeContext<RoutingSlipCompleted> context)
    {
        return context.GetVariable<Uri>(nameof(ConsumeContext.ResponseAddress));
    }

    public static Guid? GetRequestId(this ConsumeContext<RoutingSlipFaulted> context)
    {
        return context.GetVariable<Guid>(nameof(ConsumeContext.RequestId));
    } 

    public static Uri? GetResponseAddress(this ConsumeContext<RoutingSlipFaulted> context)
    {
        return context.GetVariable<Uri>(nameof(ConsumeContext.FaultAddress)) ??
               context.GetVariable<Uri>(nameof(ConsumeContext.ResponseAddress));
    } 
}

