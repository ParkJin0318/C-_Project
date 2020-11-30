using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface FileRepository
    {
        void CreateFileStats(string[] names, double[] counts, double[] profits);
    }
}
