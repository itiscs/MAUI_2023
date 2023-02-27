using ListApp.Data;
using Microsoft.Extensions.Logging;

namespace ListApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ItemPage>();

        builder.Services.AddSingleton<ProductsDatabase>();



#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
