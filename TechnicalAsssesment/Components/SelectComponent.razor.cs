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
        protected bool showDropDown;
        protected async Task OnValueChanged(ChangeEventArgs eventArg)
        {
            Value = eventArg.Value?.ToString();
            await ValueChanged.InvokeAsync(Value);

            listOfProjects = _appState.Projects?
                .Where(project => project.ProjectNumber.ToString().Contains(Value ?? string.Empty))
                .Take(10)
                .ToList()?? new();

            showDropDown = true;
            StateHasChanged();
        }
        protected async Task OnProjectSelect(ProjectModel project)
        {
            Value = project.ProjectNumber.ToString();
            ToggleDropDown();
            await SelectedProject.InvokeAsync(project);
            
        }
        protected void ToggleDropDown()
        {
            showDropDown = !showDropDown;
            StateHasChanged();
        }
    }
}
