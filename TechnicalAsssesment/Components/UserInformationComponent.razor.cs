using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Components
{
    public partial class UserInformationComponentBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        protected bool IsLoading = false;
        protected override void OnAfterRender(bool firstRender)
        {
            
            if(firstRender)
            {
                _appState.UserInformation = new();
                StateHasChanged();
            }
        }

    }
}
