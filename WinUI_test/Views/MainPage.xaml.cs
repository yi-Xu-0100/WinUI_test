using Microsoft.UI.Xaml.Controls;

using WinUI_test.ViewModels;

namespace WinUI_test.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
