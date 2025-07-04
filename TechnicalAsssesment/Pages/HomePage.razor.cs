using Microsoft.AspNetCore.Components;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Pages
{
    public  partial class HomePageBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;

        protected void OnProjectSelected(ProjectModel p)
        {

        }
    }
}
