using Kiosk.repository;
using Kiosk.model.Stats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repositoryImpl
{
    class FileRepositoryImpl : FileRepository
    {
        public void CreateFileStats(string path, List<MenuProfitsData> profits)
        {
            FileStream fs = File.Create(path + "/file.csv");
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            foreach (MenuProfitsData data in profits)
            {
                sw.WriteLine("{0},{1},{2}", data.name, data.count + "개", data.sumProfits + "원");
            }
            sw.Close();
            fs.Close();
        }
    }
}
