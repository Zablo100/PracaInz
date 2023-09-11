namespace pracaInż.Models.Entities
{
    public enum HardwareType
    {
        Computer,
        Monitor,
        Printer
    }

    public enum ActionType
    {
        Create,
        Update,
        Delete
    }
    public class Log
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
        public HardwareType? HardwareType { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime DateTime { get; set; }

        public Log(string user, string description, HardwareType hardwareType, ActionType actionType)
        {
            User = user;
            Description = description;
            HardwareType = hardwareType;
            ActionType = actionType;
            DateTime = DateTime.Now;
        }
        /// <summary>
        /// EF constructor
        /// </summary>
        private Log()
        {

        }
    }
}
