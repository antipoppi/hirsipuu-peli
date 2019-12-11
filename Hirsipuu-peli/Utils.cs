using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hirsipuu_peli
{
    class Utils
    {
        // eritelty metodina erikseen helpottaakseen sanojen lisäämistä
        public static List<string> Sanat() 
        {
            List<string> sanalista = new List<string>();
            sanalista.Add("Gepardi");
            sanalista.Add("Iguaani");
            sanalista.Add("Kärsämäki");
            sanalista.Add("Labyrintti");
            sanalista.Add("Pyramidi");
            sanalista.Add("Korsi");
            sanalista.Add("Sotka");
            sanalista.Add("Kaivo");
            return sanalista;
        }

        // Tällä arvotaan arvattava sana sanalistasta
        public static string ArvoSana() 
        {
            Random rnd = new Random();
            List<string> arvottavatSanat = Sanat();
            int rndIndeksi = rnd.Next(0, arvottavatSanat.Count);
            string arvottuSana = arvottavatSanat[rndIndeksi].ToUpper();
            return arvottuSana;
        }

        // Muuttaa arvotun sanan pelaajalle näytettäväksi salatuksi sanaksi
        public static string MuutaSana(string arvottuSana) 
        {
            StringBuilder piilosanaBuilder = new StringBuilder(arvottuSana.Length);
            for (int i = 0; i < arvottuSana.Length; i++)
            {
                piilosanaBuilder.Append("-");
            }
            string piilosana = piilosanaBuilder.ToString();
            return piilosana;
        }

        // Paljastaa salatusta sanasta kirjaimia ja palauttaa päivitetyn salatun sanan
        public static string PaljastaOsaSana(List<char>oikeatVastaukset, string arvottuSana) // 
        {
            StringBuilder näytäPelaajalle = new StringBuilder(arvottuSana.Length);
            {
                for (int i = 0; i < arvottuSana.Length; i++)
                {
                    if (oikeatVastaukset.Contains(arvottuSana[i]))
                    {
                        näytäPelaajalle.Append(arvottuSana[i]);
                    }
                    else
                    {
                        näytäPelaajalle.Append("-");
                    }
                }
                return näytäPelaajalle.ToString();
            }
        }

        // Tulostaa väärät sanat
        public static string tulostaVäärät(List<char>väärätVastaukset)
        {
            StringBuilder väärätKirjaimet = new StringBuilder(väärätVastaukset.Count);
            foreach (char value in väärätVastaukset)
            {
                väärätKirjaimet.Append(value + " ");
            }
            return väärätKirjaimet.ToString();
        }
    }
}
