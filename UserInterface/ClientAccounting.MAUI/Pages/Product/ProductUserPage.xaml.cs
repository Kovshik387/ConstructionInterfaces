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
		await this.PurchaseBorder.ScaleTo(1.05, 150);
		await this.PurchaseBorder.ScaleTo(1, 150);

		if (!await this._productVm.Purchase())
		{
			await DisplayAlert("������", "������ ��� � �������", "��");
			return;
		}

		await this.Purchases.ScaleTo(1.05, 250);
		this.Purchases.Source = "notification.png";
		await this.Purchases.ScaleTo(1, 250);

        await DisplayAlert("���������", "����� ������� ������", "��");
	}

	private async void PurchaseProducts_Click(object sender, EventArgs e) => await Shell.Current.GoToAsync("purchases_products", true);
}