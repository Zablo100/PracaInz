namespace pracaInż.Models.Entities
{
    public enum DeviceType
    {
        Server,
        NAS,
        Router,
        Switch
    }
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeviceType Type { get; set; }
        public string IPAddress { get; set; }

    }
}
