using Microsoft.UI.Xaml;
using Windows.Globalization;
using WinUI_test.Contracts.Services;
using WinUI_test.Helpers;

namespace WinUI_test.Services;

public class LanguageSelectorService : ILanguageSelectorService
{
    private const string SettingsLanguageKey = "AppRequestedLanguage";

    private const string SettingsLanguageChangedKey = "AppLanguageChanged";

    public string AppLanguage { get; set; } = ApplicationLanguages.Languages[0];
    public bool AppLanguageChanged { get; set; } = false;

    private readonly ILocalSettingsService _localSettingsService;

    public LanguageSelectorService(ILocalSettingsService localSettingsService)
    {
        _localSettingsService = localSettingsService;
    }

    public async Task InitializeAsync()
    {
        AppLanguage = await LoadLanguageFromSettingsAsync();
        AppLanguageChanged = await LoadLanguageChangedFromSettingsAsync();
        await Task.CompletedTask;
    }

    public async Task SetLanguageAsync(string appLanguage)
    {
        AppLanguage = appLanguage;

        await SetRequestedLanguageAsync();
        await SaveLanguageInSettingsAsync(AppLanguage);
        await Task.CompletedTask;
    }
    public async Task SetLanguageChangedAsync(bool appLanguageChanged)
    {
        AppLanguageChanged = appLanguageChanged;

        await SaveLanguageChangedInSettingsAsync(AppLanguageChanged);
        await Task.CompletedTask;
    }

    public async Task SetRequestedLanguageAsync()
    {
        ApplicationLanguages.PrimaryLanguageOverride = AppLanguage;
        await Task.CompletedTask;
    }

    private async Task<string> LoadLanguageFromSettingsAsync()
    {
        var languageName = await _localSettingsService.ReadSettingAsync<string>(SettingsLanguageKey);

        if (string.IsNullOrEmpty(languageName))
        {
            return ApplicationLanguages.Languages[0];
        }
        return languageName;
    }

    private async Task SaveLanguageChangedInSettingsAsync(bool applanguageChanged)
    {
        await _localSettingsService.SaveSettingAsync(SettingsLanguageChangedKey, applanguageChanged);
        await Task.CompletedTask;
    }

    private async Task<bool> LoadLanguageChangedFromSettingsAsync()
    {
        bool applanguageChanged = await _localSettingsService.ReadSettingAsync<bool>(SettingsLanguageChangedKey);
        await Task.CompletedTask;
        return applanguageChanged;
    }

    private async Task SaveLanguageInSettingsAsync(string appLanguage)
    {
        await _localSettingsService.SaveSettingAsync(SettingsLanguageKey, appLanguage);
        await Task.CompletedTask;
    }
}
