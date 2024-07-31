using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class MeasurableActivity
    {
        [Key]
        public Guid MeasurableActivityId { get; set; }
        [ForeignKey(nameof(ConfigPeriodId))] public Guid? PeriodId { get; set; }
        [ForeignKey(nameof(ConfigActivityId))] public Guid? ActivityId { get; set; }
        [ForeignKey(nameof(ConfigPerspectiveId))] public Guid? PerspectiveId { get; set; }
        [ForeignKey(nameof(ConfigSsMartaObjectivesId))] public Guid? SsMartaObjectivesId { get; set; }
        [ForeignKey(nameof(ConfigInitiativeId))] public Guid? InitiativeId { get; set; }

        public ConfigMenuItem? ConfigPeriodId { get; set; }

        public ConfigMenuItem? ConfigActivityId { get; set; }
        public ConfigMenuItem? ConfigPerspectiveId { get; set; }
        public ConfigMenuItem? ConfigSsMartaObjectivesId { get; set; }
        public ConfigMenuItem? ConfigInitiativeId { get; set; }

        public List<Implementation> Implementation { get; set; } = [];

    }
}
