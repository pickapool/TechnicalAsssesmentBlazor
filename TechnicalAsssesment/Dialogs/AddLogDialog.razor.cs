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
        protected string errorText = "Field is required*";
        protected void Submit()
        {
            int minutes;
            if (!int.TryParse(LogEntry.Duration, out minutes))
            {
                errorText = "Invalid Number";
                showError = true;
                return;
            }

            if (String.IsNullOrEmpty(LogEntry?.Duration))
            {
                showError = true;
                return;
            }

            int roundedMinutes = (int)Math.Ceiling(minutes / 15.0) * 15;
            _appState.TotalAccumulatedHours += roundedMinutes;

            showError = false;
            LogEntry.ProjectNumber = Project?.ProjectNumber;
            LogEntry.ActivityType = Activity?.ActivityType ?? Enums.ActivityType.Recruitment;
            LogEntry.UserInformation = _appState.UserInformation;
            LogEntry.RoundedMinutes = roundedMinutes;
            _appState.Projects?
                .Find(e => e.ProjectNumber == Project?.ProjectNumber)?.Activity?
                .Find(e => e.ActivityType == Activity?.ActivityType)?.LogEntries?
                .Insert(0, LogEntry);
            MudDialog?.Close(DialogResult.Ok(LogEntry));
        }
        protected void Cancel() => MudDialog?.Cancel();

    }
}
