using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;

namespace ClientAccounting.MAUI.ViewModel.SnapshotVm
{
    public class SnapshotView 
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public IList<Product> NewProducts { get; set; }
        public IList<Client> NewClients { get; set; }
        public IList<Order> NewOrders { get; set; }
        public List<RatingQuery> RatingBranch { get; set; } = new List<RatingQuery>();
        public DateOnly CurrentTime { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public SnapshotView(IProductService productService, IUserService userService)
        {
            this._productService = productService; this._userService = userService;
        }
        public void GetData()
        {
            this.NewClients = _userService.GetClients(this.CurrentTime);
            this.NewProducts = _productService.GetProductByDate(this.CurrentTime);
            this.NewOrders = _productService.GetOrderByDate(this.CurrentTime);
            this.RatingBranch = _productService.GetHighBranch(this.CurrentTime);
            //foreach (var item in ) { this.RatingBranch.Add((RatingQuery)item); }

            //this.RatingBranch = _productService.GetHighBranch(this.CurrentTime).Cast<RatingQuery>().ToList(); ;
        }

    }
}
