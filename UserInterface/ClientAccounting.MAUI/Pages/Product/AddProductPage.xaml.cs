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
            var result = await FilePicker.Default.PickAsync(new PickOptions() { FileTypes = FilePickerFileType.Images, PickerTitle = "Âûבונטעו פאיכ" }) ;
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);

                    this._addProductView.Photo = bytes;
                    
                    MemoryStream memory = new MemoryStream(bytes);   

                    this.image_product.Source = ImageSource.FromStream(() => (Stream)memory);
                    var image = ImageSource.FromStream(() => stream);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Îרטבךא", ex.Message, "Îך");
        }
    }

    private void ButtonAdd_Clicked(Object sender, EventArgs e)
    {

    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        this._addProductView.DateRelease = DateOnly.FromDateTime(e.NewDate.Date);
    }
}