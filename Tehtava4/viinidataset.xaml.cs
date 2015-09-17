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
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

  
private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filu = @"http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml";
                DataSet ds = new DataSet();
                DataView dv = new DataView();
                DataTable dt = new DataTable();
                ds.ReadXml(filu);
                dt = ds.Tables[0];
                dt.DefaultView;
                dv = DtdProcessing.DefaultView;
                dbviinit.ItemSource = dv;
                maat = new List<string>();
            }
            catch
            {
                throw;
            } 
    
                
                    }

}
}