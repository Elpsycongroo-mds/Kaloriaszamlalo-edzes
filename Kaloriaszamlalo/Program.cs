using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloriaszamlalo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Adatbevitel

            string name = "";
            double weight = 0.0;
            int goal = 0;
            int trainingDays = 0;
            int[] intensityLevels = null;

            string planType = "";
            int baseDuration = 0;
            double calorieMultiplier = 0.0;

            string input = "";
            bool isValid = false;

            Console.WriteLine("C# Projekt: Egyszerű Edzéstervező");
            Console.WriteLine();


            do
            {
                Console.Write("Kérlek add meg a teljes neved (pl. Vezetéknév Keresztnév): ");
                name = Console.ReadLine();



                string[] parts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                bool isNameFormatOk = parts.Length >= 2 && parts.All(p => !string.IsNullOrEmpty(p) && char.IsUpper(p[0]));

                if (!isNameFormatOk)
                {
                    Console.WriteLine("HIBA: Rossz név formátum! A nevek nagy betűvel kezdődnek.");
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);
        }
    }
}
