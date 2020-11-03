using Kiosk.model;
using Kiosk.remote;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.admin
{
    class AdminViewModel: BindableBase
    {
        public AdminViewModel()
        {
            SetUserList();
        }

        private List<User> _userList;
        public List<User> userList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }

        private void SetUserList()
        {
            UserRemote remote = new UserRemote();
            this.userList = remote.GetAllUser();
        }
    }
}
