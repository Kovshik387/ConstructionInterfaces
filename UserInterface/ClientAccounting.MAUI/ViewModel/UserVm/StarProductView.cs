using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAccounting.MAUI.ViewModel.UserVm
{
    public class StarProductView
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public StarProductView(IProductService productService, IUserService userService) => 
            (_productService,_userService) = (productService,userService);

        public async Task<Product> ProductDefition()
        {
            var id_client = int.Parse(await SecureStorage.Default.GetAsync("id_user"));

            var branch = await _userService.GetProductForUser(id_client);

            return await _productService.GetAnyProduct(branch);
        }
    }
}
