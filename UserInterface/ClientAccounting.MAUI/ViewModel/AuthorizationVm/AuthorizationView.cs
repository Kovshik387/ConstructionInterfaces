using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientAccounting.MAUI.ViewModel.AuthorizationVm
{
    public class AuthorizationView : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public readonly IClientService _clientService;
        public string Login { get; set; } public string Password { get; set; }

        public AuthorizationView(IClientService service) => this._clientService = service;
        public Client Authorize(string login, string password)
        {
            var client = _clientService.GetByLogin(login, password);

            if (client is null) return null;

            return client;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
