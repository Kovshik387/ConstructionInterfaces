using ClientsProject.DAL.Entities;
using ClientsProject.DAL.EF;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore;

namespace ClientsProject
{
    public partial class MainPage : ContentPage
    {
        private readonly IDbContextFactory<ClientAccountingContext> _factory;
        public List<Client> Clients { get; set; }
        public MainPage(IDbContextFactory<ClientAccountingContext> factory)
        {
            this._factory = factory;

            this.InitializeComponent();
            this.InitializeData();
            
            this.BindingContext = this;
        }

        private async void InitializeData()
        {
            using (var dbcontext = await this._factory.CreateDbContextAsync())
            {
                this.Clients = await dbcontext.Clients.ToListAsync();
            }

        }
    }
}