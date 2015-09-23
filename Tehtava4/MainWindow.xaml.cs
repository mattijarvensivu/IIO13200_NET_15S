using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
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
using System.Xml;
using System.Xml.Linq;
using System.ComponentModel;

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

           

            InitializeComponent();
            loadCombo();
        }
       

        private void buttonxml_Click(object sender, RoutedEventArgs e)
        {
            //string filu = @"http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml";
            //DataSet ds = new DataSet();
            //DataView dv = new DataView();

            //DataTable dt = new DataTable();
            //ds.ReadXml(filu);
            //dt = ds.Tables[0];
            //dt.DefaultView();
            // dv = DtdProcessing.DefaultView;
            //dbwines.ItemSource = dv;
            //maat = new List<string>();



            XDocument xmlDoc = XDocument.Load("http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml");

            var viinit = from viini in xmlDoc.Descendants("wine")
                          where viini.Element("maa").Value == viinimaat.SelectedItem.ToString()
                          select new
                          {
                              Nimi = viini.Element("nimi").Value,
                              Maa = viini.Element("maa").Value,
                              Arvio = viini.Element("arvio").Value,
                          };
            listView.Items.Clear();
            listView.Items.Add("");
            foreach (var viini in viinit)
            {
                listView.Items.Add("Name: " + viini.Nimi + "\n");
                listView.Items.Add("maa: " + viini.Maa + "\n");
                listView.Items.Add("Arvio: " + viini.Arvio + "\n");
            }

           







            /*  XDocument xmlDoc = XDocument.Load("http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml");

              var Viinikellari = from wine in xmlDoc.Descendants("nimi")
                            where wine.Element("maa").Value == viinimaat.SelectedItem.ToString()
                            select new
                            {
                                Name = wine.Element("nimi").Value,
                                City = wine.Element("pisteet").Value,
                                Age = wine.Element("maa").Value,
                            };
            */

            Viinikellari1 vk = new Viinikellari1();
            
            vk.Käyttäjä = "Matti Järvensivu";
            vk.ShowDialog();
            

        }
       
        private void loadCombo()
        {
            viinimaat.Items.Clear();

            XmlDocument doc = new XmlDocument();
       
            doc.Load("http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml");
             XmlNodeList nodeList = doc.SelectNodes("viinikellari/wine");
           
            foreach (XmlNode node in nodeList)
              if (!viinimaat.Items.Contains(node.SelectSingleNode("maa").InnerText))

            viinimaat.Items.Add(node.SelectSingleNode("maa").InnerText);
           
        }

      
    }



}
