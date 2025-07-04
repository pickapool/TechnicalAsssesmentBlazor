using Microsoft.AspNetCore.Components;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Layout
{
    public partial class MainLayoutBase : LayoutComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        [Parameter] public RenderFragment UserComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //lazy loader
            await Task.Delay(1000);
            _appState.UserInformation = new();
            StateHasChanged();
        }
        protected void OnProceed(AppStateService _state)
        {
            _appState = _state;
            StateHasChanged();
        }
    }
}
