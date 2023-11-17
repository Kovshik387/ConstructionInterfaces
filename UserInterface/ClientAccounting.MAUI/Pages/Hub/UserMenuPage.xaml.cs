namespace ClientAccounting.MAUI.Pages.Hub;

public partial class UserMenuPage : ContentPage
{
	public UserMenuPage() => InitializeComponent();
	private async void Products_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("product_list_user", true);
    private async void Purchases_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("purchases_products", true);
	private async void Purchase_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("star_product", true);
}