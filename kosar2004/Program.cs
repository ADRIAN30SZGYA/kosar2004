﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static List<Kosar> kosars = new List<Kosar>();
        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();

            Console.ReadKey();
        }

        private static void OtodikFeladat()
        {

        }

        private static void NegyedikFeladat()
        {
            Console.Write("4. feladat: Volt döntetlen? ");

            bool van = false;
            foreach (var kosar in kosars)
            {
                if (kosar.Hazai_pont == kosar.Idegen_pont)
                {
                    van = true;
                }
            }

            if (van)
                Console.WriteLine("igen");
            else
                Console.WriteLine("nem");
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine("3. feladat: Real Madrid: Hazai: " + kosars.Count(x => x.Hazai == "Real Madrid") + " Idegen: " + kosars.Count(x => x.Idegen == "Real Madrid"));
        }

        private static void MasodikFeladat()
        {
            using (StreamReader sr = new StreamReader("eredmenyek.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] tmp = sr.ReadLine().Split(';');
                    string hazai = tmp[0];
                    string idegen = tmp[1];
                    int hazai_pont = Convert.ToInt32(tmp[2]);
                    int idegen_pont = Convert.ToInt32(tmp[3]);
                    string helyszin = tmp[4];
                    DateTime idopont = Convert.ToDateTime(tmp[5]);
                    kosars.Add(new Kosar(hazai, idegen, hazai_pont, idegen_pont, helyszin, idopont));
                }
            }
        }
    }
}
