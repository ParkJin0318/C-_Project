using System;
using Kiosk.model.Stats;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repository
{
    interface FileRepository
    {
        void CreateFileStats(string path, List<MenuProfitsData> profits);
    }
}
