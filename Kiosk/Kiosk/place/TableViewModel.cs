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
using System.Windows.Media;

namespace Kiosk.place
{
    class TableViewModel : BindableBase
    {
        private readonly OrderRepository repository;

        public TableViewModel()
        {
            repository = new OrderRepositoryImpl();
            SetTables();
        }

        private List<TableData> _TableDataList;

        public List<TableData> TableDataList
        {
            get => _TableDataList;
            set => SetProperty(ref _TableDataList, value);
        }

        private void SetTables()
        {
            this.TableDataList = repository.GetAllTableInfo();
        }

        public void stopAllTimer()
        {
            for (int i = 0; i < 9; i++)
            {
                if (!this._TableDataList.ElementAt(i).canUse)
                {
                    this._TableDataList.ElementAt(i).stopTimer();
                }
            }
        }
    }
}
