using Microsoft.AspNetCore.Components;
using MudBlazor;
using TechnicalAssesment.Domain;
using TechnicalAssesment.Domain.Entities;
using TechnicalAsssesment.Dialogs;

namespace TechnicalAsssesment.Components
{
    public partial class ActivityComponent : ComponentBase
    {
        [Inject] protected IDialogService _dialogService { get; set; } = default!;
        [Parameter] public ProjectModel? Project { get; set; }
        [Parameter] public ActivityModel? Activity { get; set; }

        protected async Task OpenAddLogDialog()
        {
            var param = new DialogParameters();
            param.Add("Project", Project);
            param.Add("Activity", Activity);
            var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Large, BackdropClick = false };
            var resultDialog = await _dialogService.ShowAsync<AddLogDialog>("", param, options);
            if (resultDialog != null)
            {
                if (!resultDialog.Result.IsCanceled)
                {

                }
            }
        }
    }
}
