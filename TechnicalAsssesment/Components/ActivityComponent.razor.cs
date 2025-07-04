using Microsoft.AspNetCore.Components;
using TechnicalAssesment.Domain;
using TechnicalAssesment.Domain.Entities;

namespace TechnicalAsssesment.Components
{
    public partial class ActivityComponent : ComponentBase
    {
        [Parameter] public ProjectModel? Project { get; set; }
        [Parameter] public Enums.ActivityType? Activity { get; set; }
    }
}
