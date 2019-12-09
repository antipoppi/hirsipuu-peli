using System;
using System.Collections.Generic;
using System.Text;

namespace Hirsipuu_peli
{
    class Utils
    {
        public static List<string> Sanat() // eritelty metodina erikseen helpottaakseen sanojen lisäämistä
        {
            List<string> sanalista = new List<string>();
            sanalista.Add("Gepardi");
            sanalista.Add("Iguaani");
            sanalista.Add("Kärsämäki");
            return sanalista;
        }

        public static string ArvotaanSana() // tällä arvotaan sana
        {
            Random rnd = new Random();
            List<string> arvottavatSanat = Sanat();
            int rndIndeksi = rnd.Next(0, arvottavatSanat.Count);
            string arvottuSana = arvottavatSanat[rndIndeksi].ToUpper();
            return arvottuSana;
        }
    }
}
