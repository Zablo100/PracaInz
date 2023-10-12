namespace pracaInż.Models
{
    public enum StatusCode
    {
        Succes,
        Error,
        Warning,
        Info
    }
    public class NotificationResponse
    {
        public StatusCode StatusCode { get; set; }
        public string? Message { get; set; }

        public NotificationResponse(int status, string message)
        {
            if (status <= 0 && status < 5)
            {
                StatusCode = (StatusCode)status;
                Message = message;
            }
            else
            {
                StatusCode = StatusCode.Info;
                Message = message;
            }

        }
    }
}
