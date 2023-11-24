using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientAccounting.MAUI.ViewModel.SnapshotVm
{
    public class SnapshotView : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public event PropertyChangedEventHandler PropertyChanged;
        public IList<Product> NewProducts { get; set; }
        public IList<Client> NewClients { get; set; }
        public IList<Order> NewOrders { get; set; }
        public List<RatingQuery> RatingBranch { get; set; } = new List<RatingQuery>();
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime DateEnd { get; set; } = DateTime.Now;
        public SnapshotView(IProductService productService, IUserService userService)
        {
            this._productService = productService; this._userService = userService;
        }
        public void GetData()
        {
            this.NewClients = _userService.GetClients(DateOnly.FromDateTime(this.DateStart), DateOnly.FromDateTime(this.DateEnd));
            this.NewProducts = _productService.GetProductByDate(DateOnly.FromDateTime(this.DateStart), DateOnly.FromDateTime(this.DateEnd));
            this.NewOrders = _productService.GetOrderByDate(DateOnly.FromDateTime(this.DateStart), DateOnly.FromDateTime(this.DateEnd));
            this.RatingBranch = _productService.GetHighBranch(DateOnly.FromDateTime(this.DateStart), DateOnly.FromDateTime(this.DateEnd));
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
