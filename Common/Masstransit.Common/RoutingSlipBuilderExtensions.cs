using MassTransit;

namespace Masstransit.Common;

public static class RoutingSlipBuilderExtensions
{
    public static RoutingSlipBuilder AddRequestVariables(this RoutingSlipBuilder builder, ConsumeContext context)
    {
        if (context.RequestId.HasValue)
        {
            builder.AddVariable(nameof(ConsumeContext.RequestId), context.RequestId);
        }

        if (context.ResponseAddress != null)
        {
            builder.AddVariable(nameof(ConsumeContext.ResponseAddress), context.ResponseAddress);
        }

        if (context.FaultAddress != null)
        {
            builder.AddVariable(nameof(ConsumeContext.FaultAddress), context.FaultAddress);
        }

        return builder;
    }
}