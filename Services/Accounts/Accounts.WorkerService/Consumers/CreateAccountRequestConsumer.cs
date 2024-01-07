using Accounts.Bus.Contracts.Requests;
using Accounts.Bus.Contracts.Responses;
using Accounts.Model;
using MassTransit;
using Masstransit.Common;
using Masstransit.Common.Responses;
using MassTransit.Courier.Contracts;
using Users.Bus.Contracts.Activities;
using Users.Model;
using Users.WorkerService.Activities;
using Wallets.Bus.Contracts.Activities;
using Wallets.WorkerService.Activities;

namespace Accounts.WorkerService.Consumers
{
    public class CreateAccountRequestConsumer : 
        IConsumer<CreateAccountRequest>,
        IConsumer<RoutingSlipCompleted>,
        IConsumer<RoutingSlipFaulted>
    {
        private readonly ILogger<CreateAccountRequestConsumer> _logger;
        private readonly IEndpointNameFormatter _nameFormatter;

        public CreateAccountRequestConsumer(ILogger<CreateAccountRequestConsumer> logger, IEndpointNameFormatter nameFormatter)
        {
            _logger = logger;
            _nameFormatter = nameFormatter;
        }

        public Task Consume(ConsumeContext<CreateAccountRequest> context)
        {
            try
            {
                  _logger.LogInformation("Create Routing slip");

                  var routingSlip = CreateRoutingSlip(context);

                  return context.Execute(routingSlip);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private RoutingSlip CreateRoutingSlip(ConsumeContext<CreateAccountRequest> context)
        {
            var builder = new RoutingSlipBuilder(NewId.NextGuid());

            builder.AddSubscription(context.ReceiveContext.InputAddress, RoutingSlipEvents.ActivityCompleted | RoutingSlipEvents.ActivityFaulted);

            builder.AddRequestVariables(context);

            builder.AddVariable("Name", context.Message.UserName);

            builder.AddActivity(nameof(CreateUserActivity), 
                UriExtensions.CreateQueueUri(_nameFormatter.ExecuteActivity<CreateUserActivity, CreateUserActivityArgs>()), 
                new CreateUserActivityArgs
            {
                Name = context.Message.UserName
            });

            builder.AddActivity(nameof(CreateWalletActivity), 
                UriExtensions.CreateQueueUri(_nameFormatter.ExecuteActivity<CreateWalletActivity, CreateWalletActivityArgs>()), 
                new CreateWalletActivityArgs
                {
                    
                });

            return builder.Build();
        }



        public async Task Consume(ConsumeContext<RoutingSlipCompleted> context)
        {
            var requestId = context.GetRequestId();
            var responseAddress = context.GetResponseAddress();

            if (requestId.HasValue && responseAddress != null)
            {
                var responseEndpoint = await context.GetResponseEndpoint<CreateAccountResponse>(responseAddress, requestId);

                var user = context.GetVariable<User>(nameof(User)) ?? throw new ArgumentNullException(nameof(User));
                var wallet = context.GetVariable<Wallets.Model.Wallet>(nameof(Wallets.Model.Wallet)) ?? throw new ArgumentNullException(nameof(Wallets.Model.Wallet));

                var accountModel = new Account(user, wallet);

                await responseEndpoint.Send<CreateAccountResponse>(new CreateAccountResponse
                {
                    Account = accountModel
                });
            }
        }

        public async Task Consume(ConsumeContext<RoutingSlipFaulted> context)
        {
            var requestId = context.GetRequestId();
            var responseAddress = context.GetResponseAddress();

            if (requestId.HasValue && responseAddress != null)
            {
                var responseEndpoint = await context.GetResponseEndpoint<CreateAccountResponse>(responseAddress, requestId);
                await responseEndpoint.Send<ExceptionResponse>(new ExceptionResponse
                {
                   Exception = new Exception()
                });
            }
        }
    }
}
