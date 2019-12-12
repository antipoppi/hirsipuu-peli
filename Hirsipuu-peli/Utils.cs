using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hirsipuu_peli
{
    class Utils
    {
        // Sanalista on eritelty metodina helpottaakseen sanojen lisäämistä listaan, niin halutessaan.
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

        // tallennetaan tulos tekstitiedostoon omiin tiedostoihin ja luodaan koko polku tarvittaessa
        public static void TallennaTulos(bool voitto, string kansioNimi, string tiedostoNimi, int arvauskerrat)
        {
            try
            {
                string tiedostopolku = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                tiedostopolku = Path.Combine(tiedostopolku, kansioNimi);
                if (!File.Exists(tiedostopolku + "\\" + tiedostoNimi)) // jos tiedostoa ei löydy, se luodaan ja kirjoitetaan voiton arvo.
                {
                    try
                    {
                        Directory.CreateDirectory(tiedostopolku); // CreateDirectory luo kansion vain jos sitä ei ole.
                        using (StreamWriter sw = File.CreateText(tiedostopolku + "\\" + tiedostoNimi))
                        {
                            if (voitto == true)
                            {
                                string päivä = DateTime.Now.ToString("HH:mm (dd.MM.yyyy)");
                                sw.WriteLine("Voitto. klo: " + päivä + " Arvauskertoja jäi jäljelle: " + arvauskerrat);
                            }
                            else
                            {
                                string päivä = DateTime.Now.ToString("HH:mm (dd.MM.yyyy)");
                                sw.WriteLine("Häviö. klo: " + päivä);
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Input/output virhe: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Ei oikeutta kirjoittaa/lukea: " + ex.Message);
                    }
                    catch (NotSupportedException ex)
                    {
                        Console.WriteLine("Kansiota " + kansioNimi + " ei voi luoda: " + ex.Message);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("Päivämäärää ei voi muuttaa tekstiksi: " + ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Päivämäärää ei voi muuttaa tekstiksi: " + ex.Message);
                    }
                }
                else // jos tiedosto löytyy, lisätään tiedoston loppuun voiton arvo.
                {
                    try
                    {
                        using (StreamWriter sw = File.AppendText(tiedostopolku + "\\" + tiedostoNimi))
                        {
                            if (voitto == true)
                            {
                                string päivä = DateTime.Now.ToString("HH:mm (dd.MM.yyyy)");
                                sw.WriteLine("Voitto. klo: " + päivä + " Arvauskertoja jäi jäljelle: " + arvauskerrat);
                            }
                            else
                            {
                                string päivä = DateTime.Now.ToString("HH:mm (dd.MM.yyyy)");
                                sw.WriteLine("Häviö. klo: " + päivä);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Ei oikeutta kirjoittaa/lukea: " + ex.Message);
                    }
                    catch (NotSupportedException ex)
                    {
                        Console.WriteLine("StreamWriter ei pysty lisäämään tekstiä tiedostoon " + tiedostoNimi + ": " + ex.Message);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Kansiota " + kansioNimi + " ei löydy: " + ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Päivämäärää ei voi muuttaa tekstiksi: " + ex.Message);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Tulosta ei voi tallentaa: " + ex.Message);
            }
            catch (PlatformNotSupportedException ex)
            {
                Console.WriteLine("Tulosta ei voi tallentaa, koska järjestelmää ei tueta: " + ex.Message);
            }
        }
    }
}
