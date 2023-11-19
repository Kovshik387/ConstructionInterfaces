using ClientAccounting.MAUI.ViewModel.UserVm;
using System.Numerics;

namespace ClientAccounting.MAUI.Pages.Hub;

public partial class UserMenuPage : ContentPage, IQueryAttributable
{
    private readonly UserHubView _userHubVm;
    private int id;
    public UserMenuPage(UserHubView userHubView)
    {
        InitializeComponent();
        this._userHubVm = userHubView;
        this.BindingContext = _userHubVm;
    }

    protected override void OnAppearing()
    {
        this._userHubVm.GetNameAsync(id); this.ShellTitle.Title = _userHubVm.Message;
        base.OnAppearing();
    }

    private async void Products_Clicked(object sender, EventArgs e)
    {
        await this.Products.ScaleTo(1.05, 150);
        await this.Products.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("product_list_user", true);
    }
    private async void Purchases_Clicked(object sender, EventArgs e)
    {
        await this.Purchases.ScaleTo(1.05, 150);
        await this.Purchases.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("purchases_products", true);
    }
    private async void Purchase_Clicked(object sender, EventArgs e)
    {
        await this.Purchase.ScaleTo(1.05, 150);
        await this.Purchase.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("star_product", true);
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query) => this.id = (int)query["Id"];
}