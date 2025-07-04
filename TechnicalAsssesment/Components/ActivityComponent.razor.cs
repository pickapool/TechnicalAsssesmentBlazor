using Microsoft.AspNetCore.Components;
using MudBlazor;
using TechnicalAssesment.Domain;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;
using TechnicalAsssesment.Dialogs;

namespace TechnicalAsssesment.Components
{
    public partial class ActivityComponent : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        [Inject] protected IDialogService _dialogService { get; set; } = default!;
        [Parameter] public ProjectModel? Project { get; set; }
        [Parameter] public ActivityModel? Activity { get; set; }

        protected async Task OpenAddLogDialog()
        {
            var param = new DialogParameters();
            param.Add("Project", Project);
            param.Add("Activity", Activity);
            var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Large, BackdropClick = false };
            var dialogRef = await _dialogService.ShowAsync<AddLogDialog>("", param, options);
            var result = await dialogRef.Result;
            if (result != null)
            {
                if (!result.Canceled)
                {
                    Project = _appState.Projects?.FirstOrDefault(p => p.ProjectNumber == Project?.ProjectNumber);
                    Activity = Project?.Activity?.FirstOrDefault(a => a.ActivityType == Activity?.ActivityType);
                    StateHasChanged();
                }
            }
        }
    }
}
