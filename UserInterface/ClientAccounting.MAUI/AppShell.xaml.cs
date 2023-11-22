using ClientAccounting.MAUI.Pages;
using ClientAccounting.MAUI.Pages.Hub;
using ClientAccounting.MAUI.Pages.Product;
using ClientAccounting.MAUI.Pages.Snapshots;
using ClientAccounting.MAUI.Pages.User;

namespace ClientAccounting.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private static void RegisterRoutes()
        {
            Routing.RegisterRoute("accountinghub", typeof(AccountingMenuPage));
            Routing.RegisterRoute("addproduct", typeof(AddProductPage));
            Routing.RegisterRoute("addclient",typeof(AddClientPage));
            Routing.RegisterRoute("user", typeof(UserMenuPage));
            Routing.RegisterRoute("clientlist", typeof(ListPage));
            Routing.RegisterRoute("product_list_user",typeof(ProductListPage));
            Routing.RegisterRoute("purchases_products", typeof(PurchasesPage));
            Routing.RegisterRoute("star_product",typeof(StarProductPage));
            Routing.RegisterRoute("client",typeof(ClientPage));
            Routing.RegisterRoute("snapshot", typeof(SnaphotOfDayPage));
            Routing.RegisterRoute("userProduct", typeof(ProductUserPage));
            Routing.RegisterRoute("adminProduct", typeof(ProductPage));
        }
    }
}