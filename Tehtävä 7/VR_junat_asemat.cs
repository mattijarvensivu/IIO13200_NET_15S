using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä_7
{
    public class Asemat
    {
        public string stationName { get; set; }
        public string stationShortCode { get; set; }
    }

    public class Junat
    {

        public string trainNumber { get; set; }
        public bool cancelled { get; set; }
        public string departureDate { get; set; }
    }
}
