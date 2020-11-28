using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class User
    {
        public int idx { get; set; }

        public string name { get; set; }

        public string id { get; set; }

        public bool isAuto { get; set; }

        public string qrCode { get; set; }

        public string barCode { get; set; }
    }
}
