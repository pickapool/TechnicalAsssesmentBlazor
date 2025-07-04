using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TechnicalAssesment.Domain;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Layout
{
    public partial class MainLayoutBase : LayoutComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            //lazy loader
            await Task.Delay(1000);
            _appState.UserInformation = new();
            _appState.Projects = new();
            GenerateProject();
            StateHasChanged();
        }
        protected void OnProceed(AppStateService _state)
        {
            _appState = _state;
            StateHasChanged();
        }
        private void GenerateProject()
        {
            for (int projectNumber = 1000; projectNumber < 2000; projectNumber++)
            {
                ProjectModel project = new();
                project.ProjectNumber = projectNumber;
                project.Activity = new();
                foreach (Enums.ActivityType type in Enum.GetValues(typeof(Enums.ActivityType)))
                {
                    ActivityModel activity = new();
                    activity.ProjectNumber = project.ProjectNumber;
                    activity.ActivityType = type;
                    activity.LogEntries = new();
                    project.Activity.Add(activity);
                }
                _appState.Projects?.Add(project);
            }
        }
        protected async Task NewUser()
        {
            _appState.UserInformation = null;
            await Task.Delay(1000);
            _appState.UserInformation = new();
        }
    }
}
