using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Tehtävä8_real
{
   public class Logiikka
    {
        Palautteet kaikkipalautteet;

        public void luoPalaute(string a, string b, string c, string d, string e, string f, string g)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Palautteet));

            using (Stream input = File.OpenRead(Properties.Settings.Default.Palautteet))
                kaikkipalautteet = (Palautteet)xmlSerializer.Deserialize(input);

            Palaute uusipalaute = new Palaute
            {
                pvm = a,
                tekija = b,
                opittu = c,
                haluanoppia = d,
                hyvaa = e,
                parannettavaa = f,
                muuta = g
            };
            kaikkipalautteet.Palautteet_lista.Add(uusipalaute);

            using (Stream outputStream = File.OpenWrite(Properties.Settings.Default.Palautteet))
                xmlSerializer.Serialize(outputStream, kaikkipalautteet);

        }
    }
    [XmlRoot("palautteet")]
    public class Palautteet
    {
        [XmlElement(ElementName = "palaute")]
        public List<Palaute> Palautteet_lista { get; set; }
    }

    public class Palaute
    {
        [XmlElement]
        public string pvm { get; set; }

        [XmlElement]
        public string tekija { get; set; }

        [XmlElement]
        public string opittu { get; set; }

        [XmlElement]
        public string haluanoppia { get; set; }

        [XmlElement]
        public string hyvaa { get; set; }

        [XmlElement]
        public string parannettavaa { get; set; }

        [XmlElement]
        public string muuta { get; set; }

    }
}
