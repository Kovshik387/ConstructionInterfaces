using ClientAccounting.MAUI.Pages.Product;
using ClientAccounting.MAUI.ViewModel.ProductVm;
using ClientAccounting.MAUI.ViewModel.ReviewVm;
using ClientAccounting.MAUI.ViewModel.UserVm;

namespace ClientAccounting.MAUI.Pages.User;

public partial class PurchasesPage : ContentPage
{
	private readonly UserPurchaseView _userPurchaseVm;
    private readonly ProductView _productVm;
    private readonly ReviewView _reviewVm;
    public PurchasesPage(UserPurchaseView userPurchaseView, ProductView productView, ReviewView reviewView)
	{
		InitializeComponent();
		this._userPurchaseVm = userPurchaseView; this._productVm = productView; this._reviewVm = reviewView;
        this.BindingContext = _userPurchaseVm;
	}

    protected override async void OnAppearing()
    {
        await this._userPurchaseVm.GetProducts(); _reviewVm.ResetView();
        this.collectionView.ItemsSource = this._userPurchaseVm.Products;
        base.OnAppearing();
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not ClientsProject.DAL.Entities.Product current) return;

        _productVm.Product = current;

        var review = await _reviewVm.GetReview(this._productVm.Product.IdProduct);

        if (review is null) _reviewVm.Review = new();
        else _reviewVm.Review = review;

        await Navigation.PushAsync(new PurchaseProductPage(_productVm,_reviewVm));
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        await this._userPurchaseVm.GetProducts(e.NewTextValue); _reviewVm.ResetView();
        this.collectionView.ItemsSource = this._userPurchaseVm.Products;
    }
}