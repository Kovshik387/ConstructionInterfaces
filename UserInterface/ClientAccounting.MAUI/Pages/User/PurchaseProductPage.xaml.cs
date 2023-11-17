using ClientAccounting.MAUI.ViewModel.ProductVm;
using ClientAccounting.MAUI.ViewModel.ReviewVm;
using Plugin.ValidationRules.Extensions;

namespace ClientAccounting.MAUI.Pages.User;

public partial class PurchaseProductPage : ContentPage
{
	private readonly ProductView _productVm;
	private readonly ReviewView _reviewVm;

	private readonly Tuple<ProductView,ReviewView> _viewTuple;

    public PurchaseProductPage(ProductView productView, ReviewView reviewView)
	{
		InitializeComponent();
		_productVm = productView; _reviewVm = reviewView;

        _viewTuple = new(_productVm, _reviewVm);

        this.BindingContext = _viewTuple;
	}

    protected override void OnAppearing()
    {
        _reviewVm.Review.Date = DateOnly.FromDateTime(DateTime.Now);

        if (_reviewVm.Message == null) this.ButtonReview.IsEnabled = true;
		else this.ButtonReview.IsEnabled = false;
        
		base.OnAppearing();
    }

    private async void Review_Click(object sender, EventArgs e)
	{
		_reviewVm.Review.IdProduct = _productVm.Product.IdProduct;
		_reviewVm.Review.IdClient = int.Parse(await SecureStorage.Default.GetAsync("id_user"));

		_reviewVm.AddReview();

		this.ButtonReview.IsEnabled = false;
	}
}