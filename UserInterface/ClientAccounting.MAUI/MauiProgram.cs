using ClientAccounting.MAUI.Pages;
using ClientAccounting.MAUI.ViewModel.ClientVm;
using ClientAccounting.MAUI.ViewModel.ProductVm;
using ClientsProject.DAL.EF;
using ClientsProject.DAL.Interfaces;
using ClientsProject.DAL.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace ClientAccounting.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
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
                .AddTransient<AddClientView>()

                .AddTransient<ClientPage>()
                .AddScoped<ListPage>()

                .AddTransient<ProductsView>()
                .AddTransient<ProductView>()
                .AddTransient<AddProductView>()

                .AddTransient<ProductListPage>()
                .AddTransient<ProductPage>()
                .AddTransient<AddProductPage>()

                .AddTransient<IClientService, ClientService>()
                .AddTransient<IProductService,ProductService>();

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}