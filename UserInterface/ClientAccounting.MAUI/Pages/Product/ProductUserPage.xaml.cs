using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages.Product;

public partial class ProductUserPage : ContentPage
{
    private readonly ProductView _productVm;
	private bool isBuy;
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

        int.TryParse(this.PurchaseCount.Text, out var count);

		if (this._productVm.Count < count || this.PurchaseCount.Text == null || count == 0)
		{
			await DisplayAlert("Ошибка", "Введено некоректное количество","Ок");
			return;
		}

		if (!await this._productVm.Purchase(count))
		{
			await DisplayAlert("Ошибка", "Товара нет в наличии", "Ок");
			return;
		}

        isBuy = true;

		await this.Purchases.ScaleTo(1.05, 250);
		this.Purchases.Source = "notification.png";
		await this.Purchases.ScaleTo(1, 250);

		var ask = await DisplayAlert
			("Товар успешно куплен.","Перейти обратно?", "Остаться", "Перейти обратно");
		if (!ask) await Shell.Current.Navigation.PopModalAsync();
	}

    protected override bool OnBackButtonPressed()
    {
		if (!isBuy) _productVm.ViewProduct();
        return base.OnBackButtonPressed();
    }

    private async void PurchaseProducts_Click(object sender, EventArgs e) => await Shell.Current.GoToAsync("purchases_products", true);
}