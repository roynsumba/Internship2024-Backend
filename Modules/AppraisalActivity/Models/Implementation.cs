using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class Implementation
    {
        [Key]
        public Guid ImplementationId { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }

        [Required]
        public byte[] Evidence { get; set; } = [];
        
        public string? EvidenceContentType { get; set; } 

        public string? EvidenceFileName { get; set; } 


        [Required]
        public DateTime CreatedDate { get; set; }

        public required Guid MeasurableActivityId { get; set; }

        [ForeignKey(nameof(MeasurableActivityId))]

        [JsonIgnore]
        public MeasurableActivity? MeasurableActivity { get; set; }

        [ForeignKey("User")]
        public required Guid? UserId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
