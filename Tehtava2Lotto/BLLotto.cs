using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä2
{
    class Lotto
    {
        Random Rand = new Random();
        
        int SuurinNro;
        int NumeroLkm;

        public Lotto(int _SuurinNro, int _NumeroLkm)
        {
            this.SuurinNro = _SuurinNro;
            this.NumeroLkm = _NumeroLkm;

        }
        public int[] ArvoRivi()
        {
            

            int[] Rivi = new int[NumeroLkm];

            
            for (int i = 0; i < NumeroLkm; i++)
            {
                

                Rivi[i] = Rand.Next(1,SuurinNro);
                

       
                for (int j = 0; j < NumeroLkm; j++)
                {
                    if ((Rivi[i] == Rivi[j]) && (i != j))
                    {
                        //Arvotaan tilalle uusi luku, kun palataan ylemmän for-silmukan alkuun
                        i--;
                        break;
                    }
                }
            }
            return Rivi;


      
           
        }



    }
}
