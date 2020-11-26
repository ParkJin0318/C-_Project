using Kiosk.model.Stats;
using Kiosk.remote;
using LiveCharts;
using LiveCharts.Wpf;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.data
{
    class MCSDataViewModel : BindableBase //(Menu, Category, Seat)DataPage ViewModel
    {
        private List<MenuCategoryData> _data = new List<MenuCategoryData>();

        public List<MenuCategoryData> data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public void SetData(int modeNumber)
        {
            StatsDataRemote remote = new StatsDataRemote();
            if (modeNumber == 1)
                this.data = remote.GetMenuData(0, 9);
            else
                this.data = remote.GetCategoryData(0, 9);
        }

        public void SetData(int talbeNumber, bool mode) //true : Menu, false : Category
        {
            StatsDataRemote remote = new StatsDataRemote();
            if (mode)
                this.data = remote.GetMenuData(talbeNumber, talbeNumber);
            else
                this.data = remote.GetCategoryData(talbeNumber, talbeNumber);

        }

        public double[] GetSumCount(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(data.ElementAt(i).count));
            }
            return buffer.ToArray();
        }

        public double[] GetSumProfits(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(data.ElementAt(i).sumProfits) / 10000.0);
            }
            return buffer.ToArray();
        }

        public string[] GetNames(int startPoint, int endPoint)
        {
            List<string> buffer = new List<string>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(data.ElementAt(i).name);
            }
            return buffer.ToArray();
        }
    }
}
