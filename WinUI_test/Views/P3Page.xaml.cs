using Microsoft.UI.Xaml.Controls;

using WinUI_test.ViewModels;

namespace WinUI_test.Views;

public sealed partial class P3Page : Page
{
    public P3ViewModel ViewModel
    {
        get;
    }

    public P3Page()
    {
        ViewModel = App.GetService<P3ViewModel>();
        InitializeComponent();
    }
}
