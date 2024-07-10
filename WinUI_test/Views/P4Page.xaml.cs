using Microsoft.UI.Xaml.Controls;

using WinUI_test.ViewModels;

namespace WinUI_test.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class P4Page : Page
{
    public P4ViewModel ViewModel
    {
        get;
    }

    public P4Page()
    {
        ViewModel = App.GetService<P4ViewModel>();
        InitializeComponent();
    }
}
