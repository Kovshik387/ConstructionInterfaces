using System.Windows;
using Task2.Pages;

namespace Task2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e) => this.frameWindow.Content = new PrimaryPage();
    }
}
