namespace _05.ComposantLifecycle.Composants;

using Microsoft.AspNetCore.Components;
using System;

public partial class TabPage : ComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public bool IsActivated { get; set; }
    [Parameter] public RenderFragment AdditionalHeaderContent { get; set; }
    [Parameter] public int Key { get; set; }
    [CascadingParameter] private TabControl Parent { get; set; }


    protected override void OnInitialized()
    {
        if (Parent is null)
            throw new ArgumentNullException(nameof(Parent), @"TabPage must exist within a TabControl");

        Parent.AddPage(this);
        base.OnInitialized();
    }
}