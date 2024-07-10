using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using WinUI_test.Contracts.Services;
using WinUI_test.Contracts.ViewModels;
using WinUI_test.Core.Contracts.Services;
using WinUI_test.Core.Models;

namespace WinUI_test.ViewModels;

public partial class P3DetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private SampleOrder? item;

    public ICommand GoBackCommand
    {
        get;
    }

    public P3DetailViewModel(ISampleDataService sampleDataService, INavigationService navigationService)
    {
        _sampleDataService = sampleDataService;
        _navigationService = navigationService;

        GoBackCommand = new RelayCommand(OnGoBack);
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnGoBack()
    {
        if (_navigationService.CanGoBack)
        {
            _navigationService.GoBack();
        }
    }
}
