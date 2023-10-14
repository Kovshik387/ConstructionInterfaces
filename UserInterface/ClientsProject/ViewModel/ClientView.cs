using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProject.ViewModel
{
    public class ClientView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IClientService _clientService;
        public ObservableCollection<Review> Reviews { get; set; }
        public Client Client { get; set; }

        public ClientView(IClientService clientService)
        {
            _clientService = clientService;
            
        }

        public void GetReviews()
        {
            this.Client = _clientService.GetReviews(this.Client);
            this.Reviews = new ObservableCollection<Review>(Client.Reviews);
        }

        public string Login
        {
            get => this.Client.Login; set
            {
                if (this.Client.Login != value)
                {
                    this.Client.Login = value;
                    
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => this.Client.Password; set
            {
                if (this.Client.Password != value)
                {
                    this.Client.Password = value;
                    OnPropertyChanged();
                }
                    
            }
        }
        public string Name
        {
            get => this.Client.Name; 
            set
            {
                if (this.Client.Name != value)
                {
                    this.Client.Name = value; 
                    OnPropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => this.Client.Surname; set
            {
                if (this.Client.Surname != value)
                {
                    this.Client.Surname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Patronymic
        {
            get => this.Client.Patronymic; set
            {
                if (this.Client.Patronymic != value)
                {
                    this.Client.Patronymic = value;
                    OnPropertyChanged();
                }
                    
            }
        }
        public string Contact
        {
            get => this.Client.Contact; set
            {
                if (this.Client.Contact != value)
                {
                    this.Client.Contact = value;
                    OnPropertyChanged();
                }
                    
            }
        }
        public string Email { get => this.Client.Email; set
            {
                if (this.Client.Email != value)
                {
                    this.Client.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Rating { get => this.Client.Rating; set
            {
                if (this.Client.Rating != value)
                {
                    this.Client.Rating = value;
                    OnPropertyChanged();
                }
                     
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            _clientService.ChangeClient(new Client() 
            {
                IdClient = this.Client.IdClient,
                Name = this.Name,
                Login = this.Login,
                Password = this.Password,
                Patronymic = this.Patronymic,
                Surname = this.Surname,
                Reviews = this.Reviews,
                Contact = this.Contact,
                Email = this.Email,
                Rating = this.Rating
            });

        }
    }
}
