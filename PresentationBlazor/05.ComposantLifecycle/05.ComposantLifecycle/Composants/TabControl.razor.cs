namespace _05.ComposantLifecycle.Composants;

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

public partial class TabControl : ComponentBase
{
    private readonly List<TabPage> _tabPages = new List<TabPage>();
    private readonly List<TabHeader> _tabHeaders = new List<TabHeader>();
    private int _activeTabPageKey;
    private SessionStorageModel _sessionStorage = new();
    public TabPage ActivePage { get; private set; }
    public TabHeader ActiveHeader { get; private set; }

    public int ActivePageKey
    {
        get
            => _activeTabPageKey;

        set
        {
            if (_activeTabPageKey == value)
            {
                return;
            }

            _activeTabPageKey = value;
            ActivatePage(_tabHeaders.SingleOrDefault(t => t.Key == _activeTabPageKey));
        }
    }

    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment TabHeaderContent { get; set; }
    [Parameter] public EventCallback<TabPage> OnActivePageChanged { get; set; }
    [Parameter] public string MasterPage { get; set; }
    [Parameter] public TabControlStyle TabControlStyle { get; set; }
    [Parameter] public bool ForceToFirstTab { get; set; } = false;
    [Parameter] public int TabToMoveTo { get; set; } = 0;


    protected override void OnAfterRender(bool firstRender)
    {
        SessionStorageModel sessionStorage = new SessionStorageModel();

        if (sessionStorage is not null)
        {
            _sessionStorage = sessionStorage;

            if (!ForceToFirstTab)
            {
                if (_sessionStorage.ActiveTabPageIndex <= _tabPages.Count)
                {
                    ActivePageKey = _sessionStorage.ActiveTabPageIndex;
                }
                else
                {
                    ActivePageKey = 1;
                }
            }
        }
        else
        {
            ActivePageKey = 0;
        }
    }

    protected override void OnParametersSet()
    {
        if (TabToMoveTo != ActivePageKey && _tabHeaders.Count > 0)
        {
            TabHeader tabToMoveTo = _tabHeaders.FirstOrDefault(t => t.Key == TabToMoveTo);

            if (tabToMoveTo != null)
            {
                ActivatePage(tabToMoveTo);
            }
        }
    }

    public void ActivatePage(TabHeader tabHeader)
    {
        ActivePage = _tabPages.FirstOrDefault(t => t.Key == tabHeader.Key);
        ActiveHeader = tabHeader;

        ActivePageKey = tabHeader.Key;

        _sessionStorage.ActiveTabPageIndex = ActivePageKey;

        if (ForceToFirstTab)
        {
            _sessionStorage.ActiveTabPageIndex = 1;
        }

        StateHasChanged();
    }

    public void AddPage(TabPage tabPage)
    {
        _tabPages.Add(tabPage);

        if (_tabPages.Count == 1)
            ActivePage = tabPage;

        StateHasChanged();
    }

    private string GetStyle()
    {
        string style = TabControlStyle switch
        {
            TabControlStyle.Panel => "tab-header nav nav-tabs",
            TabControlStyle.Slash => "tab-slash",
            _ => string.Empty,
        };

        return style;
    }

    public void AddHeader(TabHeader tabHeader)
    {
        _tabHeaders.Add(tabHeader);

        if (_tabHeaders.Count == 1)
            ActiveHeader = tabHeader;

        StateHasChanged();
    }

    public string GetActiveClass(TabHeader tabHeader) => tabHeader == ActiveHeader ? "active" : string.Empty;


    private class SessionStorageModel
    {
        public int ActiveTabPageIndex { get; set; }
    }
}

public enum TabControlStyle
{
    Panel,
    Slash,
}