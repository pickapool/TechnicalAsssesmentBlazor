﻿using Microsoft.AspNetCore.Components;
using TechnicalAssesment.Infrastructure;

namespace TechnicalAsssesment.Components
{
    public partial class TextFieldComponentBase : ComponentBase
    {
        [Parameter] public string? Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public string Label { get; set; } = string.Empty;
        [Parameter] public bool ShowError { get; set; }
        [Parameter] public string? ErrorMessage { get; set; }
        protected async Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value?.ToString();
            await ValueChanged.InvokeAsync(Value);
        }
    }
}
