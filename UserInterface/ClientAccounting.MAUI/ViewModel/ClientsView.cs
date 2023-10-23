using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClientAccounting.MAUI.ViewModel
{
    public class ClientsView
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IClientService _clientService;
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public ClientsView(IClientService clientService)
        {
            this._clientService = clientService;

            this.Clients = new ObservableCollection<Client>(_clientService.GetClientAll());
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Clients = _clientService.GetSearchedClients(query);
        });

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected internal void GetSearched(string query) => Clients = _clientService.GetSearchedClients(query);
        protected internal void AddClient(Client client) { this.Clients.Add(client);  this._clientService.AddClient(client); }
        protected internal void GetAllClient() => Clients= new ObservableCollection<Client>(_clientService.GetClientAll());
    }
}
