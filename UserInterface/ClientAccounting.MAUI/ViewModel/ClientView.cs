﻿using ClientsProject.DAL.Entities;
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

namespace ClientAccounting.MAUI.ViewModel
{
    public partial class ClientView : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private readonly IClientService _clientService;
        public ObservableCollection<Review> Reviews { get; set; }
        public ObservableCollection<Order> Order { get; set; }
        public Client Client { get; set; } = new();

        public ClientView(IClientService clientService)
        {
            _clientService = clientService;
        }

        public void SaveClient() => _clientService.ChangeClient(this.Client);
        public void AddClient(Client client) => _clientService.AddClient(client);

        public void GetReviews()
        {
            this.Client = _clientService.GetInfo(this.Client);
            this.Order = new ObservableCollection<Order>(Client.Orders);
            this.Reviews = new ObservableCollection<Review>(Client.Reviews);
        }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Login
        {
            get => this.Client.Login; set
            {
                if (this.Client.Login != value)
                {
                    if (string.IsNullOrEmpty(value))
                        return;                
                    
                    this.Client.Login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => this.Client.Password; set
            {
                if (this.Client.Password != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) )
                        return;

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
                if (this.Client.Name != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    this.Client.Name = value; 
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get => this.Client.Surname; set
            {
                if (this.Client.Surname != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value) || value.Length >= 20)
                        return;

                    this.Client.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Patronymic
        {
            get => this.Client.Patronymic; set
            {
                if (this.Client.Patronymic != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value)) return;

                    this.Client.Patronymic = value;
                    OnPropertyChanged();
                }
                    
            }
        }
        public string Contact
        {
            get => this.Client.Contact; set
            {
                if (this.Client.Contact != value && value.Length <= 12)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    this.Client.Contact = value;
                    OnPropertyChanged();
                }
                    
            }
        }
        public string Email { get => this.Client.Email; set
            {
                if (this.Client.Email != value && value.Length <= 20)
                {
                    if (string.IsNullOrEmpty(value)) 
                        return;

                    this.Client.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Rating { get => this.Client.Rating; set
            {
                if (this.Client.Rating != value)
                {
                    if (value == null || value > 5)
                        return;

                    this.Client.Rating = value;
                    OnPropertyChanged();
                }
                     
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            SaveClient();
        }
    }
}
