using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class MeasurableActivity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MeasurableActivityId { get; set; }
        [Required] public string Period { get; set; } = string.Empty;
        [Required] public string Activity { get; set; } = string.Empty;
        [Required] public string Perspective { get; set; } = string.Empty;
        [Required] public string SsMartaObjectives { get; set; } = string.Empty;
        [Required] public string Initiative { get; set; } = string.Empty;

        
        public List<Implementation> Implementation { get; set; } = [];


    }
}
