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
    private Client client;

	public AddClientPage(AddClientView addClientView)
	{
		InitializeComponent();
		_addClientView = addClientView;
        this.BindingContext = _addClientView;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        _addClientView.AddClientAsync();

        await Navigation.PopAsync();
    }   
}