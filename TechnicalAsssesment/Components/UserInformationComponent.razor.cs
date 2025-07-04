using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Threading.Tasks;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Components
{
    public partial class UserInformationComponentBase : ComponentBase
    {
        [Parameter] public AppStateService AppState { get; set; }
        [Parameter] public EventCallback<AppStateService> OnProceed { get; set; }
        protected string username = string.Empty;
        protected bool showError = false;
        protected async Task SetUserInformation()
        {
            if(String.IsNullOrEmpty(username))
            {
                showError = true;
                StateHasChanged();
                return;
            }
            showError = false;
            AppState.UserInformation.UserName = username;
            await OnProceed.InvokeAsync(AppState);
            StateHasChanged();
        }
    }
}
