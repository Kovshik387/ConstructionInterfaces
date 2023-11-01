using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages;

public partial class ProductPage : ContentPage
{
	private readonly ProductView _productVm;

	public ProductPage(ProductView productView)
	{
		InitializeComponent();
		_productVm = productView;
		this.BindingContext = _productVm;
	}
}