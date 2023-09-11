namespace pracaInż.Models.Entities
{
    public class InfrastructureStatus
    {
        public Device Device { get; set; }
        public string Status { get; set; }

        public InfrastructureStatus(Device Device, string Status)
        {
            this.Device = Device;
            this.Status = Status;
        }
    }
}
