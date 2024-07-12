using System.Reflection;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;

using Windows.ApplicationModel;

using WinUI_test.Contracts.Services;
using WinUI_test.Helpers;

namespace WinUI_test.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    private readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _elementTheme;

    private readonly ILanguageSelectorService _languageSelectorService;

    [ObservableProperty]
    private string _appLanguage;

    [ObservableProperty]
    private bool _appLanguageChanged;

    [ObservableProperty]
    private string _versionDescription;

    public ICommand SwitchThemeCommand
    {
        get;
    }

    public ICommand SwitchLanguageCommand
    {
        get;
    }

    public SettingsViewModel(IThemeSelectorService themeSelectorService, ILanguageSelectorService languageSelectorService)
    {
        _versionDescription = GetVersionDescription();

        // Set SwitchThemeCommand
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) =>
            {
                if (ElementTheme != param)
                {
                    ElementTheme = param;
                    await _themeSelectorService.SetThemeAsync(param);
                }
            });

        // Set SwitchLanguageCommand
        _languageSelectorService = languageSelectorService;
        _appLanguage = _languageSelectorService.AppLanguage;
        _appLanguageChanged = _languageSelectorService.AppLanguageChanged;

        SwitchLanguageCommand = new RelayCommand<string>(
            async (param) =>
            {
                if (param is null)
                {
                    throw new ArgumentNullException(nameof(param));
                }

                if (AppLanguage != param)
                {
                    AppLanguage = param;
                    AppLanguageChanged = true;
                    await _languageSelectorService.SetLanguageAsync(param);
                    await _languageSelectorService.SetLanguageChangedAsync(AppLanguageChanged);
                    
                }
            });
    }

    private static string GetVersionDescription()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;

            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}
