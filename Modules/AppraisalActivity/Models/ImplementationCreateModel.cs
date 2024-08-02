namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class ImplementationCreateModel
    {

        public string Description { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }
        public string Evidence { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public required Guid MeasurableActivityId { get; set; }
    }
}
