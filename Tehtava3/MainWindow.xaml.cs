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
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace Tehtava3
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
    

        List<Pelaaja> Pelaajat = new List<Pelaaja>();
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        

        private void Luouusi_Click(object sender, RoutedEventArgs e)
        {
            
            
            string Kokonimi = firstname.Text + " " + lastname.Text + ", " + team.Text; // haetaan tekstikentistä pelaajan kokonimi + joukkue
            for (int i = 0; i < Pelaajat.Count(); i++)

            {
                if (Pelaajat.ElementAt(i).Kokonimi == Kokonimi) //tarkastetaan onko pelaaja jo listalla vertaamalla listan elementtien sisältö
                {
                  System.Windows.MessageBox.Show("Pelaaja on jo olemassa");
                    return;
                }

            }

            if (firstname.Text == "" || lastname.Text == "" || team.Text == "" || transfer.Text == "" ) // Tarkastetaan onko joku syötteistä tyhjä
            {

            System.Windows.MessageBox.Show("Tarkista Syöte");

            }

            else
            {
                //haetaan kaikki tiedot tesktikentistä uudestaan.

                string Etunimi = firstname.Text;
                string Sukunimi = lastname.Text;
                string Seura = team.Text;
                double Vaihtohinta = Double.Parse(transfer.Text);
                
                
                Pelaaja pelaaja = new Pelaaja(Etunimi, Sukunimi, Seura, Vaihtohinta);
                pelaaja.TallennaPelaaja(pelaaja, Pelaajat); //kayetään pelaaja luokan metodia jolla lisätään pelaaja listaan

                tallennetutpelaajat.Items.Add(pelaaja.Kokonimi); //lisätään pelaaja oikeanpuoleiseen laatikoon
                Statustext.Text = "Pelaaja lisätty";
                //Tyhjätään Palkit
                firstname.Text = ""; 
                lastname.Text="";
                team.Text= "";
                transfer.Text="";
            }
        }

        private void tallennetutpelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tallennetutpelaajat.SelectedIndex != -1) //Ettei tyhjätessä SelectedIndex heitä erroria
            {//Asetetaan tekstikenttiin oikeasta palkista valittu pelaaja
                firstname.Text = Pelaajat.ElementAt(tallennetutpelaajat.SelectedIndex).Etunimi;
                lastname.Text = Pelaajat.ElementAt(tallennetutpelaajat.SelectedIndex).Sukunimi;
                team.Text = Pelaajat.ElementAt(tallennetutpelaajat.SelectedIndex).Seura;
                transfer.Text = System.Convert.ToString(Pelaajat.ElementAt(tallennetutpelaajat.SelectedIndex).Siirtohinta);
            }
        }

     

        private void Muokkaa_Click(object sender, RoutedEventArgs e)
        {
            if (Pelaajat.Count > 0 && tallennetutpelaajat.SelectedIndex>=0) //Tarkistus että ei voi muokata tyhjää listaa tai jos et ole valinnnut pelaajaa
            {
                string Etunimi = firstname.Text;
                string Sukunimi = lastname.Text;
                string Seura = team.Text;
                double Vaihtohinta = Double.Parse(transfer.Text);
                int index = tallennetutpelaajat.SelectedIndex;
                Pelaaja pelaaja = new Pelaaja(Etunimi, Sukunimi, Seura, Vaihtohinta);
                pelaaja.MuokkaaPelaaja(index, Etunimi, Sukunimi, Seura, Vaihtohinta, Pelaajat);
                tallennetutpelaajat.Items.Clear(); //Tyhjätään oikeanpuoleinen kenttä (Jos vaikka muutoksia on tullut) 
                foreach (var Pelaaja in Pelaajat)
                {

                    tallennetutpelaajat.Items.Add(Pelaaja.Kokonimi); // Sijoitetaan data uudelleen oikeanpuoleiseen kentään


                }
                Statustext.Text = "Muokattu";
            }
            else { System.Windows.MessageBox.Show("Pelaajalistassa ei ole Muokattavaa tai et ole valinnut pelaajaa");
                Statustext.Text = "Pelaajalistalla ei muokattavaa tai et ole valinnut pelaajaa";
            }
        }

        private void Poista_Click(object sender, RoutedEventArgs e)
        {
            if (Pelaajat.Count > 0 && tallennetutpelaajat.SelectedIndex >= 0) //Tarkistus että ei voi poistaa tyhjää
            {
                Pelaajat.RemoveAt(tallennetutpelaajat.SelectedIndex);//Poistetaan pelaaja tietystä indexistä
                tallennetutpelaajat.Items.Clear(); //tyhjennetään kenttä
                foreach (var Pelaaja in Pelaajat)
                {

                    tallennetutpelaajat.Items.Add(Pelaaja.Kokonimi); //Data uudestaan kenttään


                }
                Statustext.Text = "Poistettu";
                firstname.Text = ""; //Tyhjätään syöttökentät valmiiksi
                lastname.Text = "";
                transfer.Text = "";
            }
            else {
                System.Windows.MessageBox.Show("Pelajalista on jo tyhjä tai et ole valinnut pelaajaa");
                Statustext.Text = "Pelaajalista on tyhjä tai et ole valinnut pelaajaa";
            }
        }

        private void Kirjoita_Click(object sender, RoutedEventArgs e)
        {
            string kaikkinimet = ""; //alustetaan string

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) { //Kun savefieldialogista painetaan OK jatketaan
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew)) // file.open hakee  polun minne tallennetaan, FileName minkä niminen ja creatNew päättää että tehdään uusi tiedosto
                using (StreamWriter sw = new StreamWriter(s)) { //luodaan streamwriter
                    
                    foreach (var Pelaaja in Pelaajat)
                    {
                        
                        kaikkinimet += Pelaaja.Kokonimi + System.Environment.NewLine; //Lisätään string muuttujaan dataa
                       
                    }
                    sw.Write(kaikkinimet); //Kirjoitetaan tiedostoon
                    Statustext.Text=("Tiedostoon tallennettu");
                }
            }
        }

      
        private void Lopetus_Click(object sender, RoutedEventArgs e)
        {
         
           
            this.Close(); // sulkee ohjelman
        }
    }
}
    



