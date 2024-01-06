namespace Masstransit.Common.Responses
{
    public record ExceptionResponse
    {
        public Exception Exception { get; init; } = null!;
    }
}
