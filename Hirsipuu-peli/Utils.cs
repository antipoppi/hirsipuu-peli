using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hirsipuu_peli
{
    class Utils
    {
        // eritelty metodina erikseen helpottaakseen sanojen lisäämistä listaan
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
            sanalista.Add("Frustraatio");
            sanalista.Add("Administraattori");
            sanalista.Add("Filantrooppi");
            sanalista.Add("Lykantropia");
            sanalista.Add("Ohraryyni");
            sanalista.Add("Valkosipuli");
            sanalista.Add("Puhelinverkko");
            sanalista.Add("Vastaanottovirkailija");
            sanalista.Add("Joululahjatoivomuslista");
            sanalista.Add("Kosmetologi");
            sanalista.Add("Ruumisautonkuljettaja");
            sanalista.Add("Taantumuksellinen");
            sanalista.Add("Tekstinkäsittelyohjelma");
            sanalista.Add("Hilavitkutin");
            sanalista.Add("Geeniperimä");
            sanalista.Add("Kolmiulotteisuus");
            sanalista.Add("Akvedukti");
            sanalista.Add("Joululahjapaperi");
            sanalista.Add("Muikku");
            sanalista.Add("Universumi");
            sanalista.Add("Jupiter");
            sanalista.Add("Syntetisaattori");
            sanalista.Add("Hätäkeskuspäivystäjä");
            sanalista.Add("Laaduntarkkailija");
            return sanalista;
        }

        // Tällä arvotaan arvattava sana sanalistasta
        public static string ArvoSana() 
        {
            try
            {
                Random rnd = new Random();
                List<string> arvottavatSanat = Sanat();
                int rndIndeksi = rnd.Next(0, arvottavatSanat.Count);
                string arvottuSana = arvottavatSanat[rndIndeksi].ToUpper();
                return arvottuSana;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Sanan arpominen epäonnistui: " + ex.Message);
                throw ex;
            }
        }

        // Muuttaa arvotun sanan pelaajalle näytettäväksi salatuksi sanaksi
        public static string MuutaSana(string arvottuSana) 
        {
            try
            {
                StringBuilder piilosanaBuilder = new StringBuilder(arvottuSana.Length);
                for (int i = 0; i < arvottuSana.Length; i++)
                {
                    piilosanaBuilder.Append("-");
                }
                string piilosana = piilosanaBuilder.ToString();
                return piilosana;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Arvottua sanaa ei voitu muuttaa piilosanaksi: " + ex.Message);
                throw ex;
            }
        }

        // Tarkistaa sisältääkö syöte vain kirjaimia
        public static bool VainKirjaimia(string syöte)
        {
            foreach (char c in syöte)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        // Paljastaa salatusta sanasta kirjaimia ja palauttaa päivitetyn salatun sanan
        public static string PaljastaOsaSana(List<char>oikeatVastaukset, string arvottuSana) // 
        {
            try
            {
                StringBuilder näytäPelaajalle = new StringBuilder(arvottuSana.Length);
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
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Kirjaimen paljastaminen piilosanasta epäonnistui: " + ex.Message);
                throw ex;
            }
        }

        // Tallentaa väärät kirjaimet stringin sisään
        public static string tulostaVäärät(List<char>väärätVastaukset)
        {
            try
            {
                StringBuilder väärätKirjaimet = new StringBuilder(väärätVastaukset.Count);
                foreach (char value in väärätVastaukset)
                {
                    väärätKirjaimet.Append(value + " ");
                }
                return väärätKirjaimet.ToString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Ei voitu tulostaa väärin arvattuja kirjaimia: " + ex.Message);
                throw ex;
            }
        }
    }
}
