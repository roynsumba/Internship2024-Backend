namespace AppraisalTracker.Modules.AppraisalActivity.Models
{
    public class MeasurableActivityCreateModel
    {
        public Guid? PeriodId { get; set; }
        public Guid? ActivityId { get; set; }
        public Guid? PerspectiveId { get; set; }
        public Guid? SsMartaObjectivesId { get; set; }
        public Guid? InitiativeId { get; set; }

        public List<Implementation> Implementation { get; set; } = [];

    }
}

