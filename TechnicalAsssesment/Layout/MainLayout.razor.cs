using Microsoft.AspNetCore.Components;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Layout
{
    public partial class MainLayoutBase : LayoutComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;

    }
}
