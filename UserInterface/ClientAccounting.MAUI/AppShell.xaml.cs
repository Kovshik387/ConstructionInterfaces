using ClientAccounting.MAUI.Pages;
using ClientAccounting.MAUI.Pages.Hub;
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

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("accountinghub", typeof(AccountingMenuPage));
            Routing.RegisterRoute("addproduct", typeof(AddProductPage));
            Routing.RegisterRoute("addclient",typeof(AddClientPage));
            Routing.RegisterRoute("user", typeof(UserMenuPage));
            Routing.RegisterRoute("product_list_user",typeof(ProductListPage));
            Routing.RegisterRoute("purchases_products", typeof(PurchasesPage));
            Routing.RegisterRoute("star_product",typeof(StarProductPage));
        }
    }
}