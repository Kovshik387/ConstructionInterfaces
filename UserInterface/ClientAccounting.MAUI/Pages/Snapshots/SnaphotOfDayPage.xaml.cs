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
		_snapshotVm.GetData();
		this.NewProducts.ItemsSource = _snapshotVm.NewProducts;
		this.NewPurchase.ItemsSource = _snapshotVm.NewOrders;
		this.NewUsers.ItemsSource = _snapshotVm.NewClients;
		this.RatingBranch.ItemsSource = _snapshotVm.RatingBranch;
        base.OnAppearing();
    }
}