using ClientsProject.Pages;

namespace ClientsProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("listpage", typeof(ListPage));
            Routing.RegisterRoute("clientpage",typeof(ClientPage));
        }
    }
}