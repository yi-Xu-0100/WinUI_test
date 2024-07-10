using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using WinUI_test.Contracts.ViewModels;
using WinUI_test.Core.Contracts.Services;
using WinUI_test.Core.Models;

namespace WinUI_test.ViewModels;

public partial class P4ViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public P4ViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
