
namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class ImplementationCreateModel
    {

        public string Description { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }
        public IFormFile Evidence { get; set; }= new FormFile(Stream.Null, 0, 0, "empty", "empty");

        public string? EvidenceContentType { get; set; } 

        public string? EvidenceFileName { get; set; } 
        public DateTime CreatedDate { get; set; }
        public required Guid MeasurableActivityId { get; set; }
        public required Guid UserId { get; set; }
        
    }
}
