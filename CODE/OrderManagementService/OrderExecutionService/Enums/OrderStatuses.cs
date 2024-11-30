using System.ComponentModel;

namespace OrderExecutionService.Enums
{
    public enum StatusType
    {
        Pending,
        [Description("In Progress")]
        InProgress,
        [Description("In Transit")]
        InTransit,
        Completed,
        Cancelled
    }
}
