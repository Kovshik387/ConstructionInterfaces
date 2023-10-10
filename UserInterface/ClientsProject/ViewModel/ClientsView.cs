using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClientsProject.ViewModel
{
    public class ClientsView
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IClientService _clientService;

        public Client SelectedClient { get; set; }

        public ObservableCollection<Client> Clients { get; set; } = new();
        
        public ICommand AddCommand { get; set; }

        public ClientsView(IClientService clientService)
        {
            this._clientService = clientService;
            this.Clients = new ObservableCollection<Client>(_clientService.GetClientAll());
            //Debug.WriteLine("Вошли");

            //AddCommand = new Command(() =>
            //{
            //    Debug.WriteLine("Команда не сработала");
            //    _clientService.AddClient(new Client()
            //    {
            //        Login = "Test",
            //        Contact = "453543",
            //        Email = "fdsfsdfds",
            //        Name = "fdsfdsfsd",
            //        Password = "ffdsfsd",
            //        Patronymic = "System.Windows.Input",
            //        Rating = 5,
            //        Surname = "fdsfds"
            //    });
            //});
        }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
