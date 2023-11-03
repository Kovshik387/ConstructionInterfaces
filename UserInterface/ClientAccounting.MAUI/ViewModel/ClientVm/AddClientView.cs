using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientAccounting.MAUI.ViewModel.ClientVm
{
    public class AddClientView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IClientService _clientService;

        private Client client = new();

        public AddClientView(IClientService clientService) => _clientService = clientService;

        public void AddClientAsync()
        {
            _clientService.AddClient(client);
            client = new();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Login
        {
            get => client.Login; set
            {
                if (client.Login != value)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    client.Login = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => client.Password; set
            {
                if (client.Password != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    client.Password = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Name
        {
            get => client.Name;
            set
            {
                if (client.Name != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    client.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => client.Surname; set
            {
                if (client.Surname != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    client.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Patronymic
        {
            get => client.Patronymic; set
            {
                if (client.Patronymic != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value)) return;

                    client.Patronymic = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Contact
        {
            get => client.Contact; set
            {
                if (client.Contact != value && value.Length <= 12)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    client.Contact = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Email
        {
            get => client.Email; set
            {
                if (client.Email != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    client.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? Rating
        {
            get => client.Rating; set
            {
                if (client.Rating != value)
                {
                    if (value == null || value > 5)
                        return;

                    client.Rating = value;
                    OnPropertyChanged();
                }

            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
