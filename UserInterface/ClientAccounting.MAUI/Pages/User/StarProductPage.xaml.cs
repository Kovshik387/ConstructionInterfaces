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
		var test = await _starProductVm.ProductDefition();

		this.BindingContext = test;

        base.OnAppearing();
    }

	private void Purchase_Click(object sender, EventArgs e)
	{

	}
}