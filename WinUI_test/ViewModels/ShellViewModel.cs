using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

using WinUI_test.Contracts.Services;

namespace WinUI_test.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;

    public ICommand MenuFileExitCommand
    {
        get;
    }

    public ICommand MenuSettingsCommand
    {
        get;
    }

    public ICommand MenuViewsP4Command
    {
        get;
    }

    public ICommand MenuViewsP3Command
    {
        get;
    }

    public ICommand MenuViewsP2Command
    {
        get;
    }

    public ICommand MenuViewsP1Command
    {
        get;
    }

    public ICommand MenuViewsMainCommand
    {
        get;
    }

    public INavigationService NavigationService
    {
        get;
    }

    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuFileExitCommand = new RelayCommand(OnMenuFileExit);
        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsP4Command = new RelayCommand(OnMenuViewsP4);
        MenuViewsP3Command = new RelayCommand(OnMenuViewsP3);
        MenuViewsP2Command = new RelayCommand(OnMenuViewsP2);
        MenuViewsP1Command = new RelayCommand(OnMenuViewsP1);
        MenuViewsMainCommand = new RelayCommand(OnMenuViewsMain);
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    private void OnMenuFileExit() => Application.Current.Exit();

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    private void OnMenuViewsP4() => NavigationService.NavigateTo(typeof(P4ViewModel).FullName!);

    private void OnMenuViewsP3() => NavigationService.NavigateTo(typeof(P3ViewModel).FullName!);

    private void OnMenuViewsP2() => NavigationService.NavigateTo(typeof(P2ViewModel).FullName!);

    private void OnMenuViewsP1() => NavigationService.NavigateTo(typeof(P1ViewModel).FullName!);

    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName!);
}
