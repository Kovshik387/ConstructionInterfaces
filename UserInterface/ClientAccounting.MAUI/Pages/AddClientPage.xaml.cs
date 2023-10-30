using ClientAccounting.MAUI.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ClientsProject.DAL.Entities;

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

    private void Button_Clicked(object sender, EventArgs e)
    {
        _addClientView.AddClientAsync();
        Navigation.PopAsync();
    }   
}