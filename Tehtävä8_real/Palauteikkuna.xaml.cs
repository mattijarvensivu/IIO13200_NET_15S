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
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Data;
using System.Xml;

namespace Tehtävä8_real
{
    /// <summary>
    /// Interaction logic for Palauteikkuna.xaml
    /// </summary>
    public partial class Palauteikkuna : Window
    {
        public Palauteikkuna()
        {
            InitializeComponent();
            naytakaikki();

        }
        public void naytakaikki()
        {
            DataSet dataSet = new DataSet();

            dataSet.ReadXml(Properties.Settings.Default.Palautteet);

        dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
        }
    }
}
