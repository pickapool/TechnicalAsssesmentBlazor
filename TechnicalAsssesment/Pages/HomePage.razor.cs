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
        protected override async Task OnInitializedAsync()
        {
            await LoadAllEntries();
        }
        protected async Task OnProjectSelected(ProjectModel p)
        {
            selectedProject = p;
            showSkeleton = true;
            await Task.Delay(1000);
            showSkeleton = false;
            showActivities = true;
        }
        protected async Task LoadAllEntries()
        {
            isTableLoading = true;
            await Task.Delay(1000);
            Logs = _appState.Projects?.SelectMany(e => e.Activity?? new()).SelectMany(e => e.LogEntries?? new()).ToList()?? new();
            isTableLoading = false;
        }
        protected async Task OnLogCreated(LogEntryModel log)
        {
            if (log is null) return;
            isTableLoading = true;
            await Task.Delay(1000);
            Logs.Insert(0, log);
            isTableLoading = false;
        }
    }
}
