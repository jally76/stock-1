namespace Stock.Core.Services.Common
{
    public class OperationResult
    {
        public string Message { get; set; }

        public StatusOpearion StatusOpearion { get; set; }
    }

    public enum StatusOpearion : byte
    {
        Success = 0,
        Error = 1
    }
}
