using Kiosk.model;
using Kiosk.remote;
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
            repository = new UserRepositoryImpl();
            SetUserList();
        }

        private readonly UserRepository repository;

        private List<User> _userList;
        public List<User> userList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }

        private void SetUserList()
        {
            this.userList = repository.GetAllUser();
        }
    }
}
