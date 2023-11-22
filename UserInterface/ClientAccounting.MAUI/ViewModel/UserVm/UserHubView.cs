using ClientsProject.DAL.Interfaces;

namespace ClientAccounting.MAUI.ViewModel.UserVm
{
    public class UserHubView
    {
        private IUserService _userService;
        public string Message { get; set; } = null!;
        public UserHubView(IUserService userService) => _userService = userService;
        public void GetNameAsync(int id)
        {
            var name = _userService.GetClientById(id);

            this.Message = $"Привет, {name.Name}";
        }

        public void SetLogin(int id) => this._userService.AuthoLogg(id);
    }
}
