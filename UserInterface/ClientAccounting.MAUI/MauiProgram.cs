using ClientAccounting.MAUI.Pages;
using ClientAccounting.MAUI.ViewModel;
using ClientsProject.DAL.EF;
using ClientsProject.DAL.Interfaces;
using ClientsProject.DAL.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;


namespace ClientAccounting.MAUI
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
                .AddTransient<App>()
                .AddTransient<ClientView>()
                .AddTransient<ClientsView>()
                .AddScoped<ListPage>()
                .AddTransient<ClientPage>()
                .AddTransient<IClientService, ClientService>();

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}