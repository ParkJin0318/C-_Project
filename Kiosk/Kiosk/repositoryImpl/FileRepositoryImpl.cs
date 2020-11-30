using Kiosk.repository;
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
        public void CreateFileStats(string[] names, double[] counts, double[] profits)
        {
            FileStream fs = File.Create(@"../../csv/file.csv");
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            for (int i = 0; i< names.Length; i++)
            {
                sw.WriteLine("{0},{1},{2}", names[i], counts[i], profits[i]);
            }
            sw.Close();
            fs.Close();
        }
    }
}
