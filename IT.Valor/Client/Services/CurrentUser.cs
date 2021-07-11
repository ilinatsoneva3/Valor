using System.ComponentModel;
using System.Threading.Tasks;
using IT.Valor.Common.Models;

namespace IT.Valor.Client.Services
{
    public class CurrentUser : INotifyPropertyChanged
    {
        private readonly IClientUserService _userService;

        public event PropertyChangedEventHandler PropertyChanged;

        public CurrentUser(IClientUserService userService)
        {
            _userService = userService;
            _userService.UserAuthenticatedEvent += UserAuthenticatedEvent;
        }

        public UserDto User { get; set; } = new UserDto();

        public int Counter { get; set; }

        private async void UserAuthenticatedEvent(object sender, UserAuthenticatedArgs e)
        {
            if (!string.IsNullOrEmpty(e.UserId))
            {
                await PopulateUser(e.UserId);
            }
            else
            {
                ClearUser();
            }
        }

        private async void ClearUser()
        {
            User = new UserDto();
            Counter = 0;
            NotifyPropertyChange();
        }

        private void NotifyPropertyChange()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
        }

        private async Task PopulateUser(string id)
        {
            User = await _userService.GetUserAsync(id);
            NotifyPropertyChange();
        }
    }
}
