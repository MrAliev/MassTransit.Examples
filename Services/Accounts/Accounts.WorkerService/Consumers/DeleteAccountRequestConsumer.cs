using Accounts.Bus.Contracts.Requests;
using Accounts.Bus.Contracts.Responses;
using MassTransit;
using Masstransit.Common.Responses;

namespace Accounts.WorkerService.Consumers;

public class DeleteAccountRequestConsumer : IConsumer<DeleteAccountRequest>
{
    private readonly ILogger<CreateAccountRequestConsumer> _logger;
    
    public DeleteAccountRequestConsumer(ILogger<CreateAccountRequestConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<DeleteAccountRequest> context)
    {
        try
        {
            
        }
        catch (Exception e)
        {
            await context.RespondAsync<ExceptionResponse>(new ExceptionResponse
            {
                Exception = e
            });
        }
    }
}