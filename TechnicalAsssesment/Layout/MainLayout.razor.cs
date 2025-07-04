using Microsoft.AspNetCore.Components;
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
            for (int i = 1000; i < 2000; i++)
            {
                ProjectModel project = new();
                project.ProjectNumber = i;
                foreach(Enums.ActivityType type in Enum.GetValues(typeof(Enums.ActivityType)))
                {
                    ActivityModel activity = new();
                    activity.ProjectNumber = project;
                    activity.ActivityType = type;
                    activity.LogEntries = new();
                }
                _appState.Projects.Add(project);
            }
        }
    }
}
