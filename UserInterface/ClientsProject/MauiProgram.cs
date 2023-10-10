using ClientsProject.DAL.Interfaces;
using ClientsProject.DAL.Services;
using ClientsProject.Page;
using ClientsProject.ViewModel;
using Microsoft.Extensions.Logging;

namespace ClientsProject
{
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
                })
                .Services
                .AddDbContextFactory<ClientsProject.DAL.EF.ClientAccountingContext>()
                .AddSingleton<MainPage>()
                .AddSingleton<ListPage>()
                .AddSingleton<ClientsView>()
                .AddSingleton<IClientService, ClientService>();

            #if DEBUG
	            builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}