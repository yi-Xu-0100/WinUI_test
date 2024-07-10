using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using WinUI_test.ViewModels;

namespace WinUI_test.Views;

public sealed partial class P2Page : Page
{
    public P2ViewModel ViewModel
    {
        get;
    }

    public P2Page()
    {
        ViewModel = App.GetService<P2ViewModel>();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
