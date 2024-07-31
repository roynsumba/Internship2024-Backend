using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class ImplementationCreateModel
    {

        
        public string Description { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string? Stakeholder { get; set; }
        public string Evidence { get; set; } = string.Empty;
        public DateTime Date { get; set; }

    }
}
