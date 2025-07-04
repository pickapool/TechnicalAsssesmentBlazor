using Microsoft.AspNetCore.Components;
using TechnicalAssesment.Domain.Entities;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Components
{
    public partial class SelectComponentBase : ComponentBase
    {
        [Inject] protected AppStateService _appState { get; set; } = default!;
        [Parameter] public string? Value { get; set; }
        [Parameter] public string Label { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public EventCallback<ProjectModel> SelectedProject { get; set; }
        protected List<ProjectModel> listOfProjects = new();
        protected bool showDropDown = false;
        protected override void OnInitialized()
        {
            listOfProjects = _appState.Projects?.Clone()?? new();
        }
        protected async Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value?.ToString();
            await ValueChanged.InvokeAsync(Value);
            listOfProjects = _appState.Projects
                .Where(p => p.ProjectNumber.ToString().Contains(Value ?? string.Empty))
                .Take(10)
                .ToList();
            showDropDown = true;
            StateHasChanged();
        }
        protected async Task OnProjectSelect(ProjectModel p)
        {
            Value = p.ProjectNumber.ToString();
            ToggleDropDown();
            await SelectedProject.InvokeAsync(p);
            
        }
        protected void ToggleDropDown()
        {
            showDropDown = !showDropDown;
            StateHasChanged();
        }
    }
}
