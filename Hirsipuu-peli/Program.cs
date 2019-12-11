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
            List<char> oikeatVastaukset = new List<char>();
            List<char> väärätVastaukset = new List<char>();

            Console.WriteLine("Tervetuloa pelaamaan Hirsipuu-peliä!");
            Console.WriteLine("Voit arvata kirjaimen aakkosista A-Ö tai vastata arvattavan sanan.");

            while (!voitto && arvauskerrat > 0)
            {
                Console.WriteLine("Sinulla on mahdollisuus arvata väärin " + arvauskerrat + " kertaa.");
                Console.Write("\nArvattava sana on: " + näytetäänPelaajalle + " (sana on " + arvattavaSana.Length + " kirjainta pitkä) \nArvaa: ");
                string syöte = Console.ReadLine().ToUpper();
                if (syöte.Length == arvattavaSana.Length)
                {
                    if (syöte == arvattavaSana)
                    {
                        voitto = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Vastaus on väärä!");
                        arvauskerrat--;
                        continue;
                    }
                }
                else
                {
                    char arvattuKirjain = syöte[0];
                    if (arvattavaSana.Contains(arvattuKirjain))
                    {
                        Console.Clear();
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
                Console.WriteLine("Voitit pelin! Onneksi olkoon! " + "Sana oli " + arvattavaSana + ".");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Hävisit pelin. Oikea vastaus oli: " + arvattavaSana);
            }
        }
    }
}
