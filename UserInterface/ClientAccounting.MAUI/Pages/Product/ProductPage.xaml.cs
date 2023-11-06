using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages;

public partial class ProductPage : ContentPage
{
	private readonly ProductView _productVm;

	public ProductPage(ProductView productView)
	{
		InitializeComponent();

		this._productVm = productView;
		this.BindingContext = _productVm;
	}

    protected override bool OnBackButtonPressed()
    {
        if (this.ValidName.IsNotValid || this.ValidCount.IsNotValid)
        {
            DisplayAlert("Ошибка", "Данные не были сохранены", "Ок");
            return base.OnBackButtonPressed();
        }

        _productVm.ChangeProduct();

        return base.OnBackButtonPressed();
    }
}