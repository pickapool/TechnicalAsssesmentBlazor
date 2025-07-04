using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;
using TechnicalAsssesment.Dialogs;

namespace TechnicalAsssesment.Pages
{
    public  partial class HomePageBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        protected bool showActivities = false, showSkeleton = false, showTable, isTableLoading;
        protected ProjectModel? selectedProject;
        protected List<LogEntryModel> Logs = new();
        protected async Task OnProjectSelected(ProjectModel p)
        {
            selectedProject = p;
            showSkeleton = true;
            StateHasChanged();
            await Task.Delay(2000);
            showSkeleton = false;
            showActivities = true;
        }
        protected async Task LoadAddEntries()
        {
            isTableLoading = true;
            StateHasChanged();
            await Task.Delay(1000);
            Logs = _appState.Projects.SelectMany(e => e.Activity).SelectMany(e => e.LogEntries).ToList();
            isTableLoading = false;
            StateHasChanged();
        }
    }
}
