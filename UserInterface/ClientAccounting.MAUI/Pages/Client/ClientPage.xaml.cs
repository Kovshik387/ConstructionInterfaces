using ClientAccounting.MAUI.ViewModel.ClientVm;
using ClientsProject.DAL.Entities;

namespace ClientAccounting.MAUI.Pages;

public partial class ClientPage : ContentPage, IQueryAttributable
{
    private readonly ClientView _clientView;
    public ClientPage(ClientView clientView)
	{
        InitializeComponent();
        _clientView = clientView;
        this.BindingContext = _clientView;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        this._clientView.Client = (Client)query["client"];
    }

    protected override void OnAppearing()
    {
        _clientView.GetReviews();
        this.BindingContext = _clientView; this.ReviewCount.BindingContext = _clientView;
        this.DetailClient.BindingContext = _clientView.Client; this.collectionView.ItemsSource = _clientView.Reviews;
        this.collectionViewOrder.ItemsSource = _clientView.Order; this.collectionViewClient.ItemsSource = _clientView.Views;
        this.countViewDetail.BindingContext = _clientView; this.CountBuyProducts.BindingContext = _clientView; this.countViewDetail.BindingContext = _clientView;
        base.OnAppearing(); 
    }

    protected override bool OnBackButtonPressed()
    {
        if (this.validEmail.IsNotValid || this.ValidContact.IsNotValid || this.ValidLogin.IsNotValid ||
            this.ValidName.IsNotValid || this.ValidPatr.IsNotValid || this.ValidSurname.IsNotValid || ValidPassword.IsNotValid)
        {
            DisplayAlert("Ошибка", "Данные не были сохранены", "Ок");
            return base.OnBackButtonPressed();
        }

        this._clientView.SaveClient();

        return base.OnBackButtonPressed();
    }

    private async void collectionViewClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Viewclient view)
        {
            var navParam = new Dictionary<string, object>() { {"product",view.IdProductNavigation } };
            await Shell.Current.GoToAsync("adminProduct",true,navParam);
        } 
    }

    private async void collectionViewOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Order view)
        {
            var navParam = new Dictionary<string, object>() { { "product", view.IdProductNavigation } };
            await Shell.Current.GoToAsync("adminProduct", true, navParam);
        }
    }

    private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Review view)
        {
            var navParam = new Dictionary<string, object>() { { "product", view.IdProductNavigation } };
            await Shell.Current.GoToAsync("adminProduct", true, navParam);
        }
    }
}