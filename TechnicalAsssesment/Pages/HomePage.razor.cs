using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics;
using System.Threading.Tasks;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;
using TechnicalAsssesment.Dialogs;

namespace TechnicalAsssesment.Pages
{
    public  partial class HomePageBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        protected bool showActivities, showSkeleton, showTable, showTableLoading;
        protected ProjectModel? selectedProject;
        protected List<LogEntryModel> Logs = new();
        private ActivityModel Activity = new();
        private bool isActivitySelected;
        
        protected override async Task OnInitializedAsync()
        {
            await LoadAllEntries();
        }
        protected async Task OnProjectSelected(ProjectModel project)
        {
            selectedProject = project;
            showSkeleton = true;

            await Task.Delay(1000);

            showSkeleton = false;
            showActivities = true;
        }
        protected async Task LoadAllEntries()
        {
            showTableLoading = true;
            isActivitySelected = false;

            await Task.Delay(1000);

            Logs = _appState.Projects?
                .SelectMany(project => project.Activity?? new())
                .SelectMany(activity => activity.LogEntries?? new())
                .ToList()?? new();

            showTableLoading = false;
        }
        protected async Task OnLogCreated(LogEntryModel log)
        {
            if (log is null) return;

            showTableLoading = true;
            
            await Task.Delay(1000);

            if(log.ActivityType == Activity.ActivityType && isActivitySelected)
                Logs.Insert(0, log);
            if(!isActivitySelected)
                Logs.Insert(0, log);

            showTableLoading = false;
        }
        protected async Task OnActivityShowLogs(ActivityModel activityModel)
        {
            Activity = activityModel;
            showTableLoading = true;
            isActivitySelected = true;

            await Task.Delay(1000);

            Logs = _appState.Projects?
                .SelectMany(project => project.Activity?? new())
                .Where(activity => activity.ActivityType == activityModel.ActivityType)
                .SelectMany(activity => activity.LogEntries?? new()).ToList()?? new();

            showTableLoading = false;
        }
    }
}
