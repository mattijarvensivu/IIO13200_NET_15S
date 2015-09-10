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

namespace Tehtävä1
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
      private bool IsOkay(string syote, TextBox sender)
        {
            double luku = 0;
            if (syote.Length > 0 && double.TryParse(syote, out luku))
            {
                return true;
            }


            else
            {
                MessageBox.Show("Tarkista syöte");
            }
            return false; 
        }
        private void Laske_Click(object sender, RoutedEventArgs e)
        {


            double IkkunaLeveys = Double.Parse(IkkunanLeveys.Text);
            double IkkunaKorkeus = Double.Parse(IkkunanKorkeus.Text);
            double Karmi = Double.Parse(KarminLeveys.Text);

        
            double KokoLeveys = Karmi + IkkunaLeveys;
            double KokoKorkeus = Karmi + IkkunaKorkeus;



            PintaAla.Text= (IkkunaLeveys * IkkunaKorkeus).ToString();
            KarminPiiri.Text = (2 * KokoLeveys + 2 * KokoKorkeus).ToString();
            KarminPinta.Text = ((KokoKorkeus*KokoLeveys)-(IkkunaKorkeus*IkkunaLeveys)).ToString();

        }

      

        private void KarminPiiri_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void KarminLeveys1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void PintaAla_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void IkkunanLeveys_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsOkay(IkkunanLeveys.Text, sender as TextBox);
        }

        private void IkkunanKorkeus_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsOkay(IkkunanKorkeus.Text, sender as TextBox);
        }

        private void KarminLeveys_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsOkay(KarminLeveys.Text, sender as TextBox);
        }
    }
}
