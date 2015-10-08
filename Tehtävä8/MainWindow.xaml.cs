using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;

namespace Tehtävä8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Lähetä_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists(Tehtävä8.Properties.Settings.Default.Palautteet2))
            {
                XmlDocument xmlEmloyeeDoc = new XmlDocument();
                xmlEmloyeeDoc.Load(Tehtävä8.Properties.Settings.Default.Palautteet2);
                XmlElement ParentElement = xmlEmloyeeDoc.CreateElement("Palaute");
                XmlElement PVM = xmlEmloyeeDoc.CreateElement("pvm");
                PVM.InnerText = Pvmtext.Text;
                XmlElement Nimi  = xmlEmloyeeDoc.CreateElement("tekija");
                Nimi.InnerText = Nimitext.Text;
                XmlElement Opittu = xmlEmloyeeDoc.CreateElement("opittu");
                Opittu.InnerText = Olenoppinut.Text;
                XmlElement Haluanoppia = xmlEmloyeeDoc.CreateElement("haluanoppia");
                Haluanoppia.InnerText = haluanoppia.ToString();
                XmlElement Hyvaa = xmlEmloyeeDoc.CreateElement("hyvaa");
                Hyvaa.InnerText = hyvaa.Text;
                XmlElement Parannettavaa = xmlEmloyeeDoc.CreateElement("parannettavaa");
                Parannettavaa.InnerText = parannettavaa.Text;
                XmlElement Muuta = xmlEmloyeeDoc.CreateElement("muuta");
                Muuta.InnerText = muuta.Text ;

                ParentElement.AppendChild(PVM);
                ParentElement.AppendChild(Nimi);
                ParentElement.AppendChild(Opittu);
                ParentElement.AppendChild(Haluanoppia);
                ParentElement.AppendChild(Hyvaa);
                ParentElement.AppendChild(Parannettavaa);
                ParentElement.AppendChild(Muuta);
                xmlEmloyeeDoc.DocumentElement.AppendChild(ParentElement);
                xmlEmloyeeDoc.Save(Tehtävä8.Properties.Settings.Default.Palautteet2);
                

            }
            else
            {
                MessageBox.Show("File doesnt exist!");
            }

        }

        private void Hae_Click(object sender, RoutedEventArgs e)
        {

            Palautteet kp = new Palautteet();
            kp.ShowDialog();

        }
    }
}
