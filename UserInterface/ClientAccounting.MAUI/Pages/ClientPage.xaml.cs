using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientAccounting.MAUI.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace ClientAccounting.MAUI.Pages;

public partial class ClientPage : ContentPage
{
    private readonly ClientView _clientView;
    public ClientPage(ClientView clientView)
	{
        InitializeComponent();
        _clientView = clientView;
        this.BindingContext = _clientView;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _clientView.GetReviews();
        this.collectionView.ItemsSource = _clientView.Reviews; 
    }

    protected override bool OnBackButtonPressed()
    {
        if (!this.EmailValidator.IsValid)
        {
            _clientView.SaveClient();
            return base.OnBackButtonPressed();
        }
        DisplayAlert("уюуюую", "кнУ", "влн");
        return base.OnBackButtonPressed();
    }

    private async void collectionViewSelected(object sender, EventArgs e)
    {

    }
}