using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Pages
{
    public  partial class HomePageBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        protected bool isShowActivities = false, showSkeleton = false;
        protected ProjectModel? selectedProject;
        protected async Task OnProjectSelected(ProjectModel p)
        {
            selectedProject = p;
            showSkeleton = true;
            StateHasChanged();
            await Task.Delay(2000);
            showSkeleton = false;
            isShowActivities = true;
        }
    }
}
