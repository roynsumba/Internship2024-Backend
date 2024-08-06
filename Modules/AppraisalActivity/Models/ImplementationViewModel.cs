namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class ImplementationViewModel
    {
        public Guid ImplementationId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }
        public byte[] Evidence { get; set; } = [];
        public string? EvidenceContentType { get; set; } = string.Empty;
        public string? EvidenceFileName { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public Guid MeasurableActivityId { get; set; }
        public DateTime? DateOfReceipt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
