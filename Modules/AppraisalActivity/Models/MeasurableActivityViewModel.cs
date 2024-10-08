namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class MeasurableActivityViewModel
    {
        public Guid MeasurableActivityId { get; set; }
        public Guid? PeriodId { get; set; }
        public Guid? ActivityId { get; set; }
        public Guid? PerspectiveId { get; set; }
        public Guid? SsMartaObjectivesId { get; set; }
        public Guid? InitiativeId { get; set; }

        public List<Implementation> Implementation { get; set; } = [];
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public Guid UserId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}