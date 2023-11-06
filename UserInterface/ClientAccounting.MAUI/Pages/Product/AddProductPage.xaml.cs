using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages;

public partial class AddProductPage : ContentPage
{
	private readonly AddProductView _addProductView;
	public AddProductPage(AddProductView addProductView)
	{
		InitializeComponent();
		this._addProductView = addProductView;
        this.BindingContext = _addProductView;
    }

    private async void Button_Clicked(Object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions() { FileTypes = FilePickerFileType.Images, PickerTitle = "Выберите файл" }) ;
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);

                    this._addProductView.Photo = bytes;
                    
                    MemoryStream memory = new(bytes);   

                    this.image_product.Source = ImageSource.FromStream(() => (Stream)memory);
                    var image = ImageSource.FromStream(() => stream);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", ex.Message, "Ок");
        }
    }

    protected override void OnAppearing()
    {
        _addProductView.Product = new();
        this._addProductView.DateRelease = DateOnly.FromDateTime(DateTime.Now);
        base.OnAppearing();
    }

    private async void ButtonAdd_Clicked(Object sender, EventArgs e)
    {
        if (this.ValidName.IsNotValid || this.ValidCount.IsNotValid)
        {
            await DisplayAlert("Ошибка", "Данные не были сохранены", "Ок");
            return;
        }

        _addProductView.AddProductAsync();
        _addProductView.ResetProduct();
        await Navigation.PopAsync();
    }

    protected override bool OnBackButtonPressed()
    {
        _addProductView.ResetProduct();

        return base.OnBackButtonPressed();
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        this._addProductView.DateRelease = DateOnly.FromDateTime(e.NewDate.Date);
    }
}