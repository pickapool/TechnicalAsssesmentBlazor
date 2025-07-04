using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;
using TechnicalAssesment.Domain.Entities;

namespace TechnicalAsssesment.Dialogs
{
    public partial class AddLogDialogBase : ComponentBase
    {
        [CascadingParameter] IMudDialogInstance? MudDialog { get; set; }
        [Parameter] public ProjectModel? Project { get; set; }
        [Parameter] public ActivityModel? Activity { get; set; }
        protected LogEntryModel? LogEntry = new();
        protected void Submit() => MudDialog?.Close(DialogResult.Ok(true));
        protected void Cancel() => MudDialog?.Cancel();

    }
}
