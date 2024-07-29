using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class Implementation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ImplementationId { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }

        [Required]
        public string Evidence { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }


        [Required]
        public int MeasurableActivityId { get; set; }

        [ForeignKey(nameof(MeasurableActivityId))]

        [JsonIgnore]
        public MeasurableActivity? MeasurableActivity { get; set; }

    }
}
