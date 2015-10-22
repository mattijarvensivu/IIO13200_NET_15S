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

namespace Tehtävä2











    // Olisi Kannattanut Käyttää Listview:tä. en ala sitä nyt muuttamaan

//Paljon ohjelmat mennyt sekaisin kun commitissa tiedostoja jäänyt väliin. Ja vahingossa poistin kotikoneelta homman. Koodia kyllä näkee mutta ohjelmia ei voi ajaa hirveästi




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

        private void Peli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ArvontaNappi_Click(object sender, RoutedEventArgs e)
        {
           
            int Rivimäärä = int.Parse(Rivit.Text);
            
            string ValittuPeli = Peli.Text;

            if (ValittuPeli == "Lotto")
            {
                Lotto rivi = new Lotto(39,7);
                int[][] Rivit = new int[Rivimäärä][];
                ValmiitRivit.Items.Add("Lotto numerot:"); 
                //ValmiitRivit.Text += Environment.NewLine;
                for (int i=0; i<Rivimäärä; i++)
                { 
                   
                      Rivit[i]=(rivi.ArvoRivi());

                }
              
                        for(int a = 0; a < Rivimäärä; a++)
                        {
                    for (int j = 0; j < 7; j++)
                    {
                        ValmiitRivit.Items.Add(Rivit[a][j] + ",".ToString());
                        
                        
                    }
                    //ValmiitRivit.Text += Environment.NewLine;
                }

                

            }
            if(ValittuPeli == "Viking Lotto")
            {
                Lotto rivi = new Lotto(48, 6);
                int[][] Rivit = new int[Rivimäärä][];
                ValmiitRivit.Items.Add("Viking lottonumerot:");
                //ValmiitRivit.Text += Environment.NewLine;

                for (int i = 0; i < Rivimäärä; i++)
            {

                Rivit[i] = (rivi.ArvoRivi());

            }

            for (int a = 0; a < Rivimäärä; a++)
            {
                for (int j = 0; j < 6; j++)
                {
                    ValmiitRivit.Items.Add(Rivit[a][j] + ",".ToString());

                }
                //ValmiitRivit.Text += Environment.NewLine;
            }


            }
            if (ValittuPeli == "Eurojackpot")
            {
                Lotto rivi = new Lotto(50, 5);
                Lotto TähtiNumerot = new Lotto(10,2);
                int[][] Rivit = new int[Rivimäärä][];
                int[][] TähtiRivit = new int[Rivimäärä][];
                ValmiitRivit.Items.Add("Eurojackpot numerot:"); 
                //ValmiitRivit.Text += Environment.NewLine;
                for (int i = 0; i < Rivimäärä; i++)
                {

                    Rivit[i] = (rivi.ArvoRivi());
                    TähtiRivit[i] = (TähtiNumerot.ArvoRivi());
                }

                for (int a = 0; a < Rivimäärä; a++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        ValmiitRivit.Items.Add(Rivit[a][j] + ",".ToString());

                      
                    }
                    ValmiitRivit.Items.Add(" Tähtinumerot: ");
                    for (int k = 0; k < 2; k++)
                    {
                        
                        ValmiitRivit.Items.Add(TähtiRivit[a][k] + ",".ToString());
                    }
                    //ValmiitRivit.Text += Environment.NewLine;
                   
                }


            }
        }







    }
    }

