using ClientsProject.DAL.EF;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace ClientsProject
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientAccountingContext _contextDb;
        public MainPage(ClientAccountingContext contextFactory)
        {
            InitializeComponent();
            this._contextDb = contextFactory;
        }
    }
}