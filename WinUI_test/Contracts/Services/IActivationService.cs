namespace WinUI_test.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
