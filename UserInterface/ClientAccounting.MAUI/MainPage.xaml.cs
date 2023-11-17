using ClientAccounting.MAUI.Pages;
using ClientAccounting.MAUI.Pages.Hub;
using ClientAccounting.MAUI.ViewModel.AuthorizationVm;
using ClientAccounting.MAUI.ViewModel.ClientVm;
using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthorizationView _authorizationView;

        public MainPage(AuthorizationView authorizationView)
        {
            this.InitializeComponent();
            this._authorizationView = authorizationView; this.BindingContext = _authorizationView;
        }

        private void Button_Clicked(object sender, EventArgs e) => 
            this.PasswordEntry.IsPassword = this.PasswordEntry.IsPassword == false ?  true : false;

        private async void Authorization_Click(Object sender, EventArgs e)
        {
            var client = _authorizationView.Authorize(_authorizationView.Login, _authorizationView.Password);

            if (client is null)
            {
                await DisplayAlert("Ошибка", "Данного пользователя не существует", "Ок"); return;
            }

            if (client.Type.Equals("admin"))
            {
                await SecureStorage.Default.SetAsync("role", client.Type);
                await Shell.Current.GoToAsync("accountinghub", true);
            }
            else if (client.Type.Equals("user"))
            {
                await SecureStorage.Default.SetAsync("id_user", client.IdClient.ToString());
                await SecureStorage.Default.SetAsync("role", client.Type);
                await Shell.Current.GoToAsync("user", true);
            }
        }
    }
}