using Kiosk.model;
using Kiosk.repository;
using Kiosk.repositoryImpl;
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
            this.userList = App.userList;
        }

        private List<User> _userList;
        public List<User> userList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }
    }
}