using Microsoft.UI.Xaml.Controls;

using WinUI_test.ViewModels;

namespace WinUI_test.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class P1Page : Page
{
    public P1ViewModel ViewModel
    {
        get;
    }

    public P1Page()
    {
        ViewModel = App.GetService<P1ViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
