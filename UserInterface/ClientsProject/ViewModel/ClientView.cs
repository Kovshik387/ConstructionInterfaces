﻿using ClientsProject.DAL.Entities;
using System;
using System.Collections.Generic;
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

        private Client _client;

        public ClientView(Client client) => (_client) = (client);

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
