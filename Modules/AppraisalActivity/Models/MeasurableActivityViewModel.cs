namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class MeasurableActivityViewModel
    {
        public int MeasurableActivityId { get; set; }
        public Guid? PeriodId { get; set; }
        public Guid? ActivityId { get; set; }
        public Guid? PerspectiveId { get; set; }
        public Guid? SsMartaObjectivesId { get; set; }
        public Guid? InitiativeId { get; set; }

        public List<Implementation> Implementation { get; set; } = [];
        public DateTime? DateOfReceipt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}