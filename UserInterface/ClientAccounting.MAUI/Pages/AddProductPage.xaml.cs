using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages;

public partial class AddProductPage : ContentPage
{
	private readonly AddProductView _productView;
	public AddProductPage(AddProductView addProductView)
	{
		InitializeComponent();
		this._productView = addProductView;
	}
}