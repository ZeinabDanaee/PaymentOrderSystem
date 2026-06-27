namespace OrderService.Api.Models
{
    public sealed class ErrorResponse
    {
        public int StatusCode { get; init; }

        public string Message { get; init; } = string.Empty;

        public object? Errors { get; init; }


        public ErrorResponse(
            int statusCode,
            string message,
            object? errors = null)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }
    }
}
