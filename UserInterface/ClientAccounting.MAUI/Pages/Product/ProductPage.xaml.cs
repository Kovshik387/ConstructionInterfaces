using ClientAccounting.MAUI.ViewModel.ProductVm;
using ClientsProject.DAL.Entities;

namespace ClientAccounting.MAUI.Pages;

public partial class ProductPage : ContentPage, IQueryAttributable
{
	private readonly ProductView _productVm;

	public ProductPage(ProductView productView)
	{
		InitializeComponent();

		this._productVm = productView;
    }

    protected override void OnAppearing()
    {
        _productVm.RefreshProduct();
        this.BindingContext = _productVm;
        this.SeensView.ItemsSource = _productVm.Product.Viewclients; this.BuyView.ItemsSource = _productVm.Product.Orders;
        this.ReviewView.ItemsSource = _productVm.Product.Reviews; base.OnAppearing();
    }

    private async void SeensView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Viewclient) return;

        var client = (Viewclient)e.CurrentSelection.FirstOrDefault();

        var navParameter = new Dictionary<string, object>
        {
            {"client", client.IdClientNavigation},
        };

        await Shell.Current.GoToAsync($"client",true, navParameter);
    }

    private async void ReviewView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Order) return;

        var client = (Order)e.CurrentSelection.FirstOrDefault();

        var navParameter = new Dictionary<string, object>
        {
            {"client", client.IdClientNavigation},
        };

        await Shell.Current.GoToAsync($"client", true, navParameter);
    }

    protected override bool OnBackButtonPressed()
    {
        if (this.ValidName.IsNotValid || this.ValidCount.IsNotValid 
            || this.ValidPrice.IsNotValid || this.ValidBranch.IsNotValid)
        {
            DisplayAlert("Ошибка", "Данные не были сохранены", "Ок");
            return base.OnBackButtonPressed();
        }

        _productVm.ChangeProduct();

        return base.OnBackButtonPressed();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) =>
        this._productVm.Product = (ClientsProject.DAL.Entities.Product)query["product"];

}