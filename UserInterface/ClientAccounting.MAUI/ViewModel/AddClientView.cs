using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientAccounting.MAUI.ViewModel
{
    public class AddClientView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IClientService _clientService;

        private Client client = new();

        public AddClientView(IClientService clientService) =>  this._clientService = clientService;

        public void AddClientAsync() => _clientService.AddClient(this.client);

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Login
        {
            get => this.client.Login; set
            {
                if (this.client.Login != value)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    this.client.Login = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => this.client.Password; set
            {
                if (this.client.Password != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    this.client.Password = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Name
        {
            get => this.client.Name;
            set
            {
                if (this.client.Name != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    this.client.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => this.client.Surname; set
            {
                if (this.client.Surname != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    this.client.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Patronymic
        {
            get => this.client.Patronymic; set
            {
                if (this.client.Patronymic != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value)) return;

                    this.client.Patronymic = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Contact
        {
            get => this.client.Contact; set
            {
                if (this.client.Contact != value && value.Length <= 12)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    this.client.Contact = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Email
        {
            get => this.client.Email; set
            {
                if (this.client.Email != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    this.client.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int? Rating
        {
            get => this.client.Rating; set
            {
                if (this.client.Rating != value)
                {
                    if (value == null || value > 5)
                        return;

                    this.client.Rating = value;
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
