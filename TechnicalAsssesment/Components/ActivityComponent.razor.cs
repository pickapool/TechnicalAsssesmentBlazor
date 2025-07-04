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
        [Parameter] public EventCallback<LogEntryModel> OnLogCreated { get; set; }
        [Parameter] public EventCallback<ActivityModel> OnShowActivityLog { get; set; }
        [Parameter] public ProjectModel? Project { get; set; }
        [Parameter] public ActivityModel? Activity { get; set; }

        protected async Task OpenAddLogDialog()
        {
            DialogParameters dialogParameter = new DialogParameters();
            dialogParameter.Add("Project", Project);
            dialogParameter.Add("Activity", Activity);

            DialogOptions dialogOptions = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Large, BackdropClick = false };

            IDialogReference dialogReference = await _dialogService.ShowAsync<AddLogDialog>("", dialogParameter, dialogOptions);
            DialogResult dialogResult = await dialogReference.Result;
            if (dialogResult != null)
            {
                if (!dialogResult.Canceled)
                {
                    LogEntryModel log = (LogEntryModel)dialogResult.Data;
                    Project = _appState.Projects?.FirstOrDefault(project => project.ProjectNumber == Project?.ProjectNumber);
                    Activity = Project?.Activity?.FirstOrDefault(activity => activity.ActivityType == Activity?.ActivityType);
                    await OnLogCreated.InvokeAsync(log);
                    StateHasChanged();
                }
            }
        }
        protected async Task ShowActivityLogs()
        {
            await OnShowActivityLog.InvokeAsync(Activity);
        }
    }
}
