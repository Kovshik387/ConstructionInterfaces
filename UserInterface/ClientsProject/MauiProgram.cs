using ClientsProject.DAL.EF;
using ClientsProject.DAL.Interfaces;
using ClientsProject.DAL.Services;
using ClientsProject.Pages;
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
                .AddDbContextFactory<ClientAccountingContext>()
                .AddTransient<MainPage>()
                .AddTransient<ClientPage>()
                .AddTransient<ListPage>()
                .AddTransient<ClientsView>()
                .AddTransient<App>()
                .AddTransient<ClientView>()
                .AddTransient<IClientService, ClientService>();

            #if DEBUG
	            builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}