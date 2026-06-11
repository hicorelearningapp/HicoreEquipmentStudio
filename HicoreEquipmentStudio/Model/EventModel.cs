namespace HicoreEquipmentStudio.Models
{
    public class EventModel
    {
        public int CEID { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public string SourceType { get; set; }

        public string SourceAddress { get; set; }

        public string TriggerCondition { get; set; }

        public string ReportType { get; set; }

        public bool Enabled { get; set; }

        // Details Section

        public string EventPriority { get; set; }

        public string EventCategory { get; set; }

        public string AlarmRelated { get; set; }

        public int MinimumInterval { get; set; }

        public string Data1 { get; set; }

        public string Data2 { get; set; }
    }
}