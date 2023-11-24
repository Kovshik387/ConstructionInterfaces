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

        int.TryParse(this.PurchaseCount.Text, out var count);

        if (this._starProductVm.Count < count || this.PurchaseCount.Text == null || count == 0)
        {
            await DisplayAlert("������", "������� ����������� ����������", "��");
            return;
        }

        if (!await this._starProductVm.Purchase(count))
        {
            await DisplayAlert("������", "������ ��� � �������", "��");
            return;
        }

        this.BindingContext = await _starProductVm.ProductDefition();

        var ask = await DisplayAlert
            ("����� ������� ������.", "������� �������?", "��������", "������� �������");
        if (!ask) await Shell.Current.Navigation.PopModalAsync();
    }

}