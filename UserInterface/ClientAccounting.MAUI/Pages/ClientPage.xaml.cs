using ClientAccounting.MAUI.ViewModel;

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
        if (this.validEmail.IsNotValid || this.ValidContact.IsNotValid || this.ValidLogin.IsNotValid ||
            this.ValidName.IsNotValid || this.ValidPatr.IsNotValid || this.ValidSurname.IsNotValid || ValidPassword.IsNotValid)
        {
            DisplayAlert("������", "������ �� ���� ���������", "��");
        }
        return base.OnBackButtonPressed();
    }

}