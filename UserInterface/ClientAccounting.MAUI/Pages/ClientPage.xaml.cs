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
        this.collectionViewOrder.ItemsSource = _clientView.Order;
    }

    protected override bool OnBackButtonPressed()
    {
        if (this.validEmail.IsNotValid)
        {
            DisplayAlert("Ошибка", "Данные не были сохранены", "Ок");
        }
        return base.OnBackButtonPressed();
    }

}