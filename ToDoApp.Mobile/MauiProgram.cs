using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using ToDoApp.Mobile.Services;

namespace ToDoApp.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>()
			.ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddHttpClient();
		builder.Services.AddFluentUIComponents();
		builder.Services.AddSingleton<CameraService>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}