using System;
using System.Collections.Generic;

namespace Hirsipuu_peli
{
    class Program
    {
        static void Main(string[] args)
        {
            string arvattavaSana = Utils.ArvoSana();
            string näytetäänPelaajalle = Utils.MuutaSana(arvattavaSana);
            bool voitto = false;
            int arvauskerrat = 10;
            string syöte = null;
            List<char> oikeatVastaukset = new List<char>();
            List<char> väärätVastaukset = new List<char>();

            Console.WriteLine("Tervetuloa pelaamaan Hirsipuu-peliä!");
            Console.WriteLine("Voit arvata kirjaimen aakkosista A-Ö tai vastata arvattavan sanan.");

            while (!voitto && arvauskerrat > 0)
            {
                Console.WriteLine("Sinulla on mahdollisuus arvata väärin " + arvauskerrat + " kertaa.");
                Console.Write("\nArvattava sana on: " + näytetäänPelaajalle + " (sana on " + arvattavaSana.Length + " kirjainta pitkä) \nArvaa: ");
                try
                {
                    syöte = Console.ReadLine().ToUpper();
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine("Muisti ei riitä: " + ex.Message);
                }
                if (syöte.Length == arvattavaSana.Length)
                {
                    if (syöte == arvattavaSana)
                    {
                        voitto = true;
                    }
                    else if (!Utils.VainKirjaimia(syöte)) // tästä ei rangaista, koska pelaaja voi kirjoittaa kirjoitusvirheen.
                    {
                        Console.Clear();
                        Console.WriteLine("Kirjoitit " + syöte);
                        Console.WriteLine("Tästä vastauksesta ei rangaista.\nKäytä vain kirjaimia, sillä vastaus ei saa sisältää erikoismerkkejä tai numeroita.\nYritä uudestaan.");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Vastaus " + syöte + " on väärä!");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        arvauskerrat--;
                        continue;
                    }
                }
                else if (syöte.Length > 1 && syöte.Length < arvattavaSana.Length) // näistä ei rangaista, koska pelaaja voi kirjoittaa vahingossa liian lyhyen vastauksen.
                {
                    if (!Utils.VainKirjaimia(syöte))
                    {
                        Console.Clear();
                        Console.WriteLine("Kirjoitit " + syöte);
                        Console.WriteLine("Tästä vastauksesta ei rangaista.\nKäytä vain kirjaimia, sillä vastaus ei saa sisältää erikoismerkkejä tai numeroita.\nYritä uudestaan.");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        continue;
                    }
                    else if (Utils.VainKirjaimia(syöte))
                    {
                        Console.Clear();
                        Console.WriteLine("Kirjoitit " + syöte);
                        Console.WriteLine("Tästä vastauksesta ei rangaista, sillä vastauksessa ei ole tarvittava määrä kirjaimia.\nYritä uudestaan.");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        continue;
                    }
                }
                else if (syöte.Length > arvattavaSana.Length) // näistä ei rangaista, koska pelaaja voi kirjoittaa vahingossa liian pitkän vastauksen.
                {
                    if (!Utils.VainKirjaimia(syöte))
                    {
                        Console.Clear();
                        Console.WriteLine("Kirjoitit " + syöte);
                        Console.WriteLine("Tästä vastauksesta ei rangaista, sillä se on liian pitkä ja se sisältää erikoismerkkejä/numeroita.\nYritä uudestaan.");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        continue;
                    }
                    else if (Utils.VainKirjaimia(syöte))
                    {
                        Console.Clear();
                        Console.WriteLine("Kirjoitit " + syöte);
                        Console.WriteLine("Tästä vastauksesta ei rangaista, sillä siinä on liikaa kirjaimia.\nYritä uudestaan.");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        continue;
                    }
                }
                else
                {
                    char arvattuKirjain = syöte[0];
                    if (!Char.IsLetter(arvattuKirjain))
                    {
                        Console.Clear();
                        Console.WriteLine(arvattuKirjain + " ei ole kirjain. Käytä kirjaimia!");
                        continue;
                    }
                    else if (arvattavaSana.Contains(arvattuKirjain))
                    {
                        Console.Clear();
                        if (oikeatVastaukset.Contains(arvattuKirjain))
                        {
                            Console.Clear();
                            Console.WriteLine("Olet jo arvannut kirjaimen " + syöte[0] + " oikein. Yritä jotain toista kirjainta! (tästä ei lähtenyt yrityskertaa)");
                            Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                            continue;
                        }
                        else
                        {
                            oikeatVastaukset.Add(arvattuKirjain);
                            for (int i = 0; i < arvattavaSana.Length; i++)
                            {
                                if (arvattavaSana[i] == arvattuKirjain)
                                {
                                    näytetäänPelaajalle = Utils.PaljastaOsaSana(oikeatVastaukset, arvattavaSana);
                                }
                            }
                            Console.WriteLine("Sanasta löytyy kirjain " + arvattuKirjain + ".");
                            Console.WriteLine("Olet yrittänyt kirjaimia " + Utils.tulostaVäärät(väärätVastaukset));
                            if (näytetäänPelaajalle == arvattavaSana)
                            {
                                voitto = true;
                            }
                        }
                    }
                    else if (väärätVastaukset.Contains(syöte[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Olet jo yrittänyt kirjainta " + syöte[0] + ". Yritä jotain toista. (tästä ei lähtenyt yrityskertaa)");
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        väärätVastaukset.Add(arvattuKirjain);
                        Console.WriteLine("Sanasta ei löydy kirjainta: " + arvattuKirjain);
                        Console.WriteLine("Olet yrittänyt seuraavia vääriä kirjaimia: " + Utils.tulostaVäärät(väärätVastaukset));
                        arvauskerrat--;
                        continue;
                    }
                }
            } 
            if (voitto == true)
            {
                Console.Clear();
                Console.WriteLine("Voitit pelin! Sana oli " + arvattavaSana + " ja sinulle jäi " + arvauskerrat + " arvauskertaa jäljelle.\nOnneksi olkoon! ");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Hävisit pelin. Oikea vastaus oli: " + arvattavaSana);
            }
        }
    }
}
