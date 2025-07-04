namespace TechnicalAssesment.Domain.Entities
{
    public class ActivityModel
    {
        public long? ProjectNumber { get; set; }
        public Enums.ActivityType ActivityType { get; set; }
        public List<LogEntryModel>? LogEntries { get; set; }
    }
}
