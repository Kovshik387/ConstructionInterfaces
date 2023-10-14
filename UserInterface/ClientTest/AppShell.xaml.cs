namespace ClientTest
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("page",typeof(page));
        }
    }
}