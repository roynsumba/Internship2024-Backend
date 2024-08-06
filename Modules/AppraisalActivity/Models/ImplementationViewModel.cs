namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class ImplementationViewModel
    {
        public Guid ImplementationId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }
        public string? EvidenceFileName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Guid MeasurableActivityId { get; set; }
        public Guid UserId { get; set; }
    }
}
