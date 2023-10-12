namespace ClientsProject
{
    public partial class App : Application
    {
        public App(MainPage main)
        {
            InitializeComponent();

            MainPage = new NavigationPage(main);
        }
    }
}