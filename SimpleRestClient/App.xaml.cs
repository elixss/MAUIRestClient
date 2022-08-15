using SimpleRestClient.Services;
namespace SimpleRestClient;

public partial class App : Application
{
	public static IServiceProvider services;
	public static IAlertService alertService;
	public App(IServiceProvider provider)
	{
		InitializeComponent();
		services = provider;
		alertService = services.GetService<IAlertService>();

		MainPage = new AppShell();
	}
}
