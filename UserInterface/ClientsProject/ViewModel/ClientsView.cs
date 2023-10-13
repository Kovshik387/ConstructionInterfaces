using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClientsProject.ViewModel
{
    public class ClientsView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        
        private readonly IClientService _clientService;
        public ObservableCollection<Client> Clients {  get; set; }
        public ClientsView(IClientService clientService)
        {
            this._clientService = clientService;

            this.Clients = new ObservableCollection<Client>(_clientService.GetClientAll());
        }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        protected internal void UpdateClients(Client client)
        {
            this.Clients[Clients.IndexOf(Clients.First(id => id.IdClient == client.IdClient))] = client;
        }
        protected internal void GetClientsAll() => this.Clients = new ObservableCollection<Client>(_clientService.GetClientAll());
        protected internal void AddClient(Client client) { this.Clients.Add(client);  this._clientService.AddClient(client); }
        protected internal ObservableCollection<Client> GetAllClient() => new ObservableCollection<Client>(_clientService.GetClientAll());
    }
}
