namespace Masstransit.Common
{
    public static class UriExtensions
    {
        public static Uri CreateQueueUri(string queueAddress)
        {
            return new Uri($"queue:{queueAddress}");
        }

        public static Uri CreateExchangeUri(string exchangeAddress)
        {
            return new Uri($"exchange:{exchangeAddress}");
        }
    }
}
