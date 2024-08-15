
namespace AppraisalTracker.Modules.AppraisalActivity.Models;

public class MeasurableActivityCreateModel
{
    public required Guid PeriodId { get; set; }
    public required Guid ActivityId { get; set; }
    public required  Guid PerspectiveId { get; set; }
    public required Guid SsMartaObjectivesId { get; set; }
    public required  Guid InitiativeId { get; set; }
    public required Guid UserId { get; set; }

    public bool IsDeleted { get; set; } = false;

}

