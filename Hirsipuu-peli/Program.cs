using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hirsipuu_peli
{
    class Program
    {
        static void Main(string[] args)
        {
            string arvattavaSana = Utils.ArvotaanSana();
            StringBuilder näytetäänPelaajalle = new StringBuilder(arvattavaSana.Length);
            for (int i = 0; i < arvattavaSana.Length; i++)
            {
                näytetäänPelaajalle.Append("-");
            }

            Console.WriteLine(näytetäänPelaajalle);
            Console.WriteLine(arvattavaSana);
        }
    }
}
