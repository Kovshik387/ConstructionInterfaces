using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.ValidationRules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientAccounting.MAUI.ViewModel.ClientVm
{
    public partial class ClientView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IClientService _clientService;
        public ObservableCollection<Review> Reviews { get; set; }
        public ObservableCollection<Order> Order { get; set; }
        public IList<Viewclient> Views { get; set; }
        public int CountView { get; set; } = default;
        public int CountReview { get; set; } = default;
        public int CountPurchase { get; set; } = default;
        public Client Client { get; set; } = new();

        public ClientView(IClientService clientService) => _clientService = clientService;

        public void SaveClient() => _clientService.ChangeClient(Client);
        public void AddClient(Client client) => _clientService.AddClient(client);

        public void GetReviews()
        {
            Client = _clientService.GetInfo(Client); 
            Order = new ObservableCollection<Order>(Client.Orders);
            Reviews = new ObservableCollection<Review>(Client.Reviews);
            Views = new List<Viewclient>(Client.Viewclients);
            this.CountView = Views.Count;
            this.CountReview = Reviews.Count;
            this.CountPurchase = Client.Orders.Count; 
        }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Login
        {
            get => Client.Login; set
            {
                if (Client.Login != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    Client.Login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => Client.Password; set
            {
                if (Client.Password != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    Client.Password = value;
                    OnPropertyChanged();
                }

            }
        }

        public string Name
        {
            get => Client.Name;
            set
            {
                if (Client.Name != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    Client.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get => Client.Surname; set
            {
                if (Client.Surname != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    Client.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Patronymic
        {
            get => Client.Patronymic; set
            {
                if (Client.Patronymic != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value)) return;

                    Client.Patronymic = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Contact
        {
            get => Client.Contact; set
            {
                if (Client.Contact != value && value.Length <= 12)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    Client.Contact = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Email
        {
            get => Client.Email; set
            {
                if (Client.Email != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    Client.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Rating
        {
            get => Client.Rating; set
            {
                if (Client.Rating != value)
                {
                    if (value == null || value > 5)
                        return;

                    Client.Rating = value;
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
