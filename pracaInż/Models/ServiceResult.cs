namespace pracaInż.Models
{
    public enum ServiceResultStatus
    {
        Created,
        Deleted,
        Updated,
        Success
    }
    public class ServiceResult<T>
    {
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }

        public ServiceResult()
        {
            
        }

        public ServiceResult(string errorMessage)
        {
            IsError = true;
            ErrorMessage = errorMessage;
        }

        public ServiceResult(ServiceResultStatus status, T customMessage)
        {
            IsError = false;
            Value = customMessage;
        }
    }
}
