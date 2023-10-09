using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClientsProject.ViewModel
{
    public class ClientView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IClientService _clientService;

        public ObservableCollection<Client> Clients { get; set; } = new();
        
        public ICommand AddCommand { get; set; }

        public ClientView(IClientService clientService)
        {
            this._clientService = clientService;
            this.Clients = new ObservableCollection<Client>(_clientService.GetClientAll());

            AddCommand = new Command(() =>
            {
                Clients.Add(new Client()
                {
                    Login = "XUESOS",
                    Contact = "453543",
                    Email = "fdsfsdfds",
                    Name = "fdsfdsfsd",
                    Password = "ffdsfsd",
                    Patronymic = "System.Windows.Input",
                    Rating = 5,
                    Surname = "fdsfds"
                });
                clientService.SaveChanges();
            });
        }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
