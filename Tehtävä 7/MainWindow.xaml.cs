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
using Newtonsoft.Json;
using System.Net;
using Tehtävä_7;

namespace Tehtävä7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string JSON = "";
        string JSON1 = "";
        public MainWindow()
        {
            InitializeComponent();
            Alusta();
        }

        private void Alusta()
        {
            JSON = haeAsemat();
            List<Asemat> asemat = JsonConvert.DeserializeObject<List<Asemat>>(JSON);
            paikkakunnat.ItemsSource = asemat;
            paikkakunnat.DisplayMemberPath = "stationName";
            paikkakunnat.SelectedValuePath = "stationShortCode";
        }

        
       

        private string haeAikataulu(string param)
        {
            try
            {
                string url = string.Format("http://rata.digitraffic.fi/api/v1/live-trains?station=" + param);
                using (WebClient wc = new WebClient())
                {
                    var jsonppi = wc.DownloadString(url);
                    return jsonppi;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private string haeAsemat()
        {
            try
            {
                string url = string.Format("http://rata.digitraffic.fi/api/v1/metadata/station");
                using (WebClient wc = new WebClient())
                {
                    var jsonppi = wc.DownloadString(url);
                    return jsonppi;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnHae_Click(object sender, RoutedEventArgs e)
            {
                string param = paikkakunnat.SelectedValue.ToString();
                JSON1 = haeAikataulu(param);
                List<Junat> junat = JsonConvert.DeserializeObject<List<Junat>>(JSON1);
                dataGrid.ItemsSource = junat;
            }
        
    }
}
