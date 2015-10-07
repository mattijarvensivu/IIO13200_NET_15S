using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tehtävä_7
{
    class DBPlacebo
    {
        string url = "http://rata.digitraffic.fi/api/v1/live-trains?station";
        public string trainnumber { get; set; }
        public Boolean cancelled{get;set;}
        public DateTime DepartureDate { get; set; }


        public string HaeJSON(string kaupunki, string url)
        {
            string kokourl =url+"="+kaupunki;

            return kokourl;
           

        }











    }

  
}
