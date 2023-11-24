using ClientAccounting.MAUI.ViewModel.SnapshotVm;

namespace ClientAccounting.MAUI.Pages.Snapshots;

public partial class SnaphotOfDayPage : ContentPage
{
	private readonly SnapshotView _snapshotVm;
	public SnaphotOfDayPage(SnapshotView snaphot)
	{
		InitializeComponent();
		this._snapshotVm = snaphot;
		this.BindingContext = _snapshotVm;
	}

    protected override void OnAppearing()
    {
        FetchData(); base.OnAppearing();
    }

	private void FetchData()
	{
        _snapshotVm.GetData();
        this.NewProducts.ItemsSource = _snapshotVm.NewProducts;
        this.NewPurchase.ItemsSource = _snapshotVm.NewOrders;
        this.NewUsers.ItemsSource = _snapshotVm.NewClients;
        this.RatingBranch.ItemsSource = _snapshotVm.RatingBranch;
    }

    private async void SeachByDate_Clicked(object sender, EventArgs e)
    {
        await this.SeachByDate.ScaleTo(1.01, 500);
        await this.SeachByDate.ScaleTo(1, 500);
        FetchData();
        this.GridDate.IsVisible = true;
        await GridDate.ScaleTo(1.05, 1000);
        await GridDate.ScaleTo(1, 1000);
    }
}