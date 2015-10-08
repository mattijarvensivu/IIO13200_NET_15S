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

namespace Tehtävä8_real
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Logiikka logiikka = new Logiikka();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void hae_Click(object sender, RoutedEventArgs e)
        {
            Palauteikkuna pi= new Palauteikkuna();
            pi.ShowDialog();
            
        }

        private void lisaa_Click(object sender, RoutedEventArgs e)
        {

            if (Pvmtext.Text != "" && Nimitext.Text != "" && haluanoppia.Text != "" && Olenoppinut.Text != "" && hyvaa.Text != "" &&
                parannettavaa.Text != "" && muuta.Text != "")
            {
                try
                {
                    logiikka.luoPalaute(Pvmtext.Text,Nimitext.Text,Olenoppinut.Text,haluanoppia.Text, hyvaa.Text,parannettavaa.Text,muuta.Text);
                    MessageBox.Show("Palaute tallennettu");
                }
                catch
                {
                    throw;
                }
            }
            else { MessageBox.Show("Jätit joitain tietoja antamatta");

            }




        }
    }
}
