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
            this.PasswordEntry.IsPassword = PasswordEntry.IsPassword == false;

        protected override async void OnAppearing()
        {
            this.Logo.IsVisible = true; this.Logo.IsEnabled = true;
            this.Logo.Opacity = 1;

            startBorder.IsEnabled = false; startBorder.IsVisible = false;

            await this.Logo.FadeTo(0, 2500); this.Logo.IsVisible = false; this.Logo.IsEnabled = false;

            this.startBorder.IsVisible = true; this.startBorder.IsEnabled = true;

            this.Activity.IsVisible = false; this.Activity.IsRunning = false;
            base.OnAppearing();
        }

        private async void Authorization_Click(Object sender, EventArgs e)
        {
            this.Activity.IsVisible = true; this.Activity.IsRunning = true;

            await this.ButtonAuth.ScaleTo(1.05, 100);
            await this.ButtonAuth.ScaleTo(1, 100);

            var client = _authorizationView.Authorize(_authorizationView.Login, _authorizationView.Password);

            if (client is null)
            {
                await DisplayAlert("Ошибка", "Данного пользователя не существует", "Ок");
                this.Activity.IsVisible = false; this.Activity.IsRunning = false;
                return;
            }

            var id_user = client.IdClient.ToString();

            var id = int.Parse(id_user);

            if (client.Type.Equals("admin"))
            {
                await SecureStorage.Default.SetAsync("id_user", id_user);
                await SecureStorage.Default.SetAsync("role", client.Type);
                await Shell.Current.GoToAsync("accountinghub", true);
            }
            else if (client.Type.Equals("user"))
            {
                await SecureStorage.Default.SetAsync("id_user", id_user);
                await SecureStorage.Default.SetAsync("role", client.Type);

                var navParameter = new Dictionary<string, object>
                {
                    {"Id",id }
                };

                await Shell.Current.GoToAsync($"user", true, navParameter);
            }
        }
    }
}