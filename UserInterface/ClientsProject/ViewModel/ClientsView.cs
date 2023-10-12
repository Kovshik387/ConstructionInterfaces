using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
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
        public Client Client { get; set; }

        public int current_id;

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


        //public string Login
        //{
        //    get => this.Client.Login; set
        //    {
        //        if (this.Client.Login != value)
        //        {
        //            this.Client.Login = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public string Password
        //{
        //    get => this.Client.Password; set
        //    {
        //        if (this.Client.Password != value)
        //        {
        //            this.Client.Password = value;
        //            OnPropertyChanged();
        //        }

        //    }
        //}
        //public string Name
        //{
        //    get => this.Client.Name;
        //    set
        //    {
        //        if (this.Client.Name != value)
        //        {
        //            this.Client.Name = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public string Surname
        //{
        //    get => this.Client.Surname; set
        //    {
        //        if (this.Client.Surname != value)
        //        {
        //            this.Client.Surname = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public string Patronymic
        //{
        //    get => this.Client.Patronymic; set
        //    {
        //        if (this.Client.Patronymic != value)
        //        {
        //            this.Client.Patronymic = value;
        //            OnPropertyChanged();
        //        }

        //    }
        //}
        //public string Contact
        //{
        //    get => this.Client.Contact; set
        //    {
        //        if (this.Client.Contact != value)
        //        {
        //            this.Client.Contact = value;
        //            OnPropertyChanged();
        //        }

        //    }
        //}
        //public string Email
        //{
        //    get => this.Client.Email; set
        //    {
        //        if (this.Client.Email != value)
        //        {
        //            this.Client.Email = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public int? Rating
        //{
        //    get => this.Client.Rating; set
        //    {
        //        if (this.Client.Rating != value)
        //        {
        //            this.Client.Rating = value;
        //            OnPropertyChanged();
        //        }

        //    }
        //}

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
