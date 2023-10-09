﻿using ClientsProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProject.DAL.Interfaces
{
    public interface IClientService
    {
        public Task<List<Client>> GetClientAllAsync();
        public List<Client> GetClientAll();
        public Task<Client?> GetClientByIdAsync(int id);
        public void SaveChanges();
    }
}
