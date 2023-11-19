using ClientAccounting.MAUI.ViewModel.UserVm;
using ClientsProject.DAL.Interfaces;

namespace ClientAccounting.MAUI.Pages.User;

public partial class StarProductPage : ContentPage
{
	private readonly StarProductView _starProductVm;
	public StarProductPage(StarProductView starProduct)
	{
		InitializeComponent();
		_starProductVm = starProduct;
	}

    protected override async void OnAppearing()
    {
        this.BindingContext = await _starProductVm.ProductDefition(); ;

        base.OnAppearing();
    }

	private async void Purchase_Click(object sender, EventArgs e)
	{
        await PurchaseButton.ScaleTo(1.05, 150);
		await PurchaseButton.ScaleTo(1, 150);

        if (!await this._starProductVm.Purchase())
        {
            await DisplayAlert("Ошибка", "Товара нет в наличии", "Ок");
            return;
        }

        this.BindingContext = await _starProductVm.ProductDefition();

        

        await DisplayAlert("Сообщение", "Товар успешно куплен", "Ок");
    }

}