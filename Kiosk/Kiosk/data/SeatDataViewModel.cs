using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kiosk.data
{
    class SeatDataViewModel : BindableBase
    {
        private List<model.TableData> _tableDatas = new List<model.TableData>();

        public List<model.TableData> tableDatas
        {
            get => _tableDatas;
            set => SetProperty(ref _tableDatas, value);
        }

        public void SetTable()
        {
            SolidColorBrush red = new SolidColorBrush(Colors.Red);
            SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
            model.TableData bufferTD = new model.TableData();

            bufferTD.myTableNumber = 1;
            bufferTD.TableColor = yellow;
            tableDatas.Add(bufferTD);

            for (int i = 2; i < 10; i++)
            {
                model.TableData bufferTD2 = new model.TableData();
                bufferTD2.myTableNumber = i;
                bufferTD2.TableColor = red;
                tableDatas.Add(bufferTD2);
            }
        }

        public SeatDataViewModel()
        {
            SetTable();
        }
    }
}
