using CommunityToolkit.Maui;
using SimpleRestClient.ViewModel;
using SimpleRestClient.Services;

namespace SimpleRestClient;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("CascadiaMono.ttf", "Cascadia Mono");
        }).UseMauiCommunityToolkit();

        // adding services
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<IAlertService, AlertService>();
        return builder.Build();
    }
}