namespace _05.ComposantLifecycle.Composants;

using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;

public partial class TabHeader : ComponentBase
{
    [Parameter] public RenderFragment AdditionalHeaderContent { get; set; }
    [Parameter] public string Text { get; set; }
    [Parameter] public int Key { get; set; }
    [CascadingParameter] private TabControl Parent { get; set; }

    protected override void OnInitialized()
    {
        if (Parent is null)
        {
            throw new ArgumentNullException(string.Format(
                CultureInfo.InvariantCulture,
                "Tab must exist",
                nameof(Parent)));
        }
        Parent.AddHeader(this);
        base.OnInitialized();
    }

    private string GetActiveClass() => this == Parent.ActiveHeader ? "active" : string.Empty;
}