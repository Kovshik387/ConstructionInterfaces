using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages.Product;

public partial class ProductUserPage : ContentPage
{
    private readonly ProductView _productVm;
    public ProductUserPage(ProductView productView)
	{
		InitializeComponent();
		this._productVm = productView;
		this.BindingContext = _productVm;
	}

	private async void Purchase_Click(Object sender, EventArgs e)
	{
		if (!await this._productVm.Purchase())
		{
			await DisplayAlert("Ошибка", "Товара нет в наличии", "Ок");
			return;
		}
		await DisplayAlert("Сообщение", "Товар успешно куплен", "Ок");
	}
}