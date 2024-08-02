using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppraisalTracker.Modules.Users;

namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class ConfigMenuItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ItemId { get; set; }

        public string FieldName { get; set; } = string.Empty;

        public string FieldDescription { get; set; } = string.Empty;

        // Foreign key for User
        [ForeignKey("User")]
        public required Guid UserId { get; set; }
    }
}
