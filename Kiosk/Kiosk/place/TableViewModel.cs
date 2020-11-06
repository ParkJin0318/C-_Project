using Kiosk.model;
using Kiosk.remote;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.place
{
    class TableViewModel : BindableBase
    {
        public TableViewModel()
        {
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
            TableDataRemote remote = new TableDataRemote();
            this.TableDataList = remote.GetLastOrderTimes();
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
