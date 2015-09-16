using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tehtava3
{
    class Pelaaja
    {
      public  string Etunimi;
      public  string Sukunimi;
      public readonly string Kokonimi; // ainoastan luettava kokonimi
      public string Seura;
      public double Siirtohinta;

 
        public Pelaaja(string _Etunimi,string _Sukunimi,string _Seura, double _Siirtohinta ) {
            Etunimi = _Etunimi;
            Sukunimi = _Sukunimi;
            Seura = _Seura;
            Siirtohinta = _Siirtohinta;
            Kokonimi = Etunimi + " " + Sukunimi + ", " + Seura; // yhdistetään readonly kokonimi muista tiedoista
        }
       

        public void TallennaPelaaja(Pelaaja Peluri, List<Pelaaja> PelaajaLista)
        {

            PelaajaLista.Add(Peluri); //lisätään pelaaja pelaajalistaan
        }
      


        public void MuokkaaPelaaja(int index, string _Etunimi, string _Sukunimi, string _Seura, double _Siirtohinta, List<Pelaaja> Pelaajalista) {
            //muokkaa pelaaja poistaa muokattavan vanhan pelaajan ja korvaa sen uudella muokatulla pelaajalla
            Pelaaja UusiPelaaja = new Pelaaja(_Etunimi, _Sukunimi, Seura, _Siirtohinta);
            Pelaajalista.RemoveAt(index);
            Pelaajalista.Insert(index, UusiPelaaja);



         

        }


    }
}
