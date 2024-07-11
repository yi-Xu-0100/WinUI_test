using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Foundation;
using Windows.System;
using WinUI_test.Helpers;
using WinUI_test.ViewModels;
using WinUI_test.Services;
using WinUI_test.Contracts.Services;

namespace WinUI_test.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public string Version
    {
        get
        {
            var version = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version;
            return string.Format("{0}.{1}.{2}.{3}", version?.Major, version?.Minor, version?.Build, version?.Revision);
        }
    }
    public string WinAppSdkRuntimeDetails => App.WinAppSdkRuntimeDetails;
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
        Loaded += OnSettingsPageLoaded;
    }

    private void OnSettingsPageLoaded(object sender, RoutedEventArgs e)
    {
        // set default theme
        var currentTheme = ViewModel.ElementTheme;
        switch (currentTheme)
        {
            case ElementTheme.Light:
                themeMode.SelectedIndex = 0;
                break;
            case ElementTheme.Dark:
                themeMode.SelectedIndex = 1;
                break;
            case ElementTheme.Default:
                themeMode.SelectedIndex = 2;
                break;
        }

    }
    private void themeMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            // check value to ElementTheme enum
            var selectedTheme = (ElementTheme)Enum.Parse(typeof(ElementTheme), ((ComboBoxItem)themeMode.SelectedItem)?.Tag?.ToString()!);
            ViewModel.SwitchThemeCommand.Execute(selectedTheme);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Parser ElementTheme error: {ex}");
        }
    }

    private void bugRequestCard_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void navigationLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void languageMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}
