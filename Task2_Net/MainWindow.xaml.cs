using System.Windows;
using Task2_Net.Pages;

namespace Task2_Net
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
