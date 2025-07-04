using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;
using TechnicalAssesment.Domain;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Dialogs
{
    public partial class AddLogDialogBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        [CascadingParameter] IMudDialogInstance? MudDialog { get; set; }
        [Parameter] public ProjectModel? Project { get; set; }
        [Parameter] public ActivityModel? Activity { get; set; }
        protected LogEntryModel? LogEntry = new();
        protected bool showError = false;
        protected void Submit()
        {
            if(String.IsNullOrEmpty(LogEntry?.Time))
            {
                showError = true;
                StateHasChanged();
                return;
            }
            showError = false;
            LogEntry.ProjectNumber = Project?.ProjectNumber;
            LogEntry.ActivityType = Activity?.ActivityType ?? Enums.ActivityType.Recruitment;
            LogEntry.UserInformation = _appState.UserInformation;
            LogEntry.Duration = LogEntry.Time;

            _appState.Projects?
                .Find(e => e.ProjectNumber == Project?.ProjectNumber)?.Activity?
                .Find(e => e.ActivityType == Activity?.ActivityType)?.LogEntries?
                .Insert(0, LogEntry);
            MudDialog?.Close(DialogResult.Ok(true));
        }
        protected void Cancel() => MudDialog?.Cancel();

    }
}
