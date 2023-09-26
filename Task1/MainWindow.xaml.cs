using System.Windows;
using Task1.Pages;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Hyperlink_Click(object sender, RoutedEventArgs e) => this.frameWindow.Content = new PrimaryPage();
        
    }
}
