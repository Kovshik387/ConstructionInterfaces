using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ClientsProject.DAL.Entities;
using ClientAccounting.MAUI.ViewModel.ClientVm;

namespace ClientAccounting.MAUI.Pages;

public partial class AddClientPage : ContentPage
{
	private readonly AddClientView _addClientView;

	public AddClientPage(AddClientView addClientView)
	{
		InitializeComponent();
		_addClientView = addClientView;
        this.BindingContext = _addClientView;
	}

    protected override bool OnBackButtonPressed()
    {
        this._addClientView.ResetClient();
        return base.OnBackButtonPressed();
    }

    protected override void OnAppearing()
    {
        this._addClientView.ResetClient();
        this._addClientView.client = new();
        this._addClientView.client.Type = "user";
        base.OnAppearing();
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (this.validEmail.IsNotValid || this.ValidContact.IsNotValid || this.ValidLogin.IsNotValid ||
        this.ValidName.IsNotValid || this.ValidPatr.IsNotValid || this.ValidSurname.IsNotValid || ValidPassword.IsNotValid)
        {
            await DisplayAlert("Ошибка", "Данные не были сохранены", "Ок");
            return;
        }
        _addClientView.AddClientAsync();
        await Navigation.PopAsync();
    }   
}