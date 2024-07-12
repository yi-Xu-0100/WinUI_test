using Microsoft.UI.Xaml;

namespace WinUI_test.Contracts.Services;

public interface ILanguageSelectorService
{
    string AppLanguage
    {
        get;
    }
    bool AppLanguageChanged
    {
        get;
    }

    Task InitializeAsync();

    Task SetLanguageAsync(string appLanguage);

    Task SetLanguageChangedAsync(bool appLanguageChanged);

    Task SetRequestedLanguageAsync();

}
