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

            // 2. Edzésterv paraméterek

            do
            {
                Console.Write("Testsúly (kg-ban, 50 és 120 között, valós szám): ");
                input = Console.ReadLine();

                if (double.TryParse(input, out weight))
                {
                    if (weight >= 50.0 && weight <= 120.0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("HIBA: A testsúlynak 50.0 és 120.0 kg között kell lennie.");
                        isValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Érvénytelen bevitel! Kérlek valós számot írj be. Figyeld hogy vesszővel írd be!");
                    isValid = false;
                }
            } while (!isValid);

            Console.WriteLine("\nKérlek válaszd ki a célod számát: 1=Állóképesség, 2=Izomtömeg, 3=Fogyás");
            do
            {
                Console.Write("Választott cél (1, 2 vagy 3): ");
                input = Console.ReadLine();

                if (int.TryParse(input, out goal))
                {
                    if (goal >= 1 && goal <= 3)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("HIBA: Csak 1, 2 vagy 3 lehet a cél.");
                        isValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Kérlek egész számot írj be.");
                    isValid = false;
                }
            } while (!isValid);


            Console.WriteLine("\n Edzésterv paraméterek beállítása");
            switch (goal)
            {
                case 1:
                    planType = "Futás/Kerékpározás (Állóképesség)";
                    baseDuration = 45;
                    calorieMultiplier = 0.12;
                    break;
                case 2:
                    planType = "Súlyzós edzés (Izomtömeg)";
                    baseDuration = 60;
                    calorieMultiplier = 0.10;
                    break;
                case 3:
                    planType = "Intervall edzés (Fogyás)";
                    baseDuration = 30;
                    calorieMultiplier = 0.15;
                    break;
                default:

                    planType = "Érvénytelen cél";
                    baseDuration = 0;
                    Console.WriteLine("HIBA: A beolvasott cél érvénytelen volt. A program leáll.");
                    return;                                                                                                                                                                                                                                             // K a p
            }

            Console.WriteLine($"Kiválasztott típus: {planType}");
            Console.WriteLine($"Edzés alaphossz: {baseDuration} perc");

            do
            {
                Console.Write("Hány napot szeretnél edzeni a héten (1-7 között): ");
                input = Console.ReadLine();

                if (int.TryParse(input, out trainingDays))
                {
                    if (trainingDays >= 1 && trainingDays <= 7)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("HIBA: Az edzésnapok száma 1 és 7 között kell legyen.");
                        isValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Kérlek egész számot írj be.");
                    isValid = false;
                }
            } while (!isValid);

            intensityLevels = new int[trainingDays];
            Console.WriteLine("\nMost add meg minden napra az erősségi szintet:");

            for (int i = 0; i < trainingDays; i++)
            {
                int level = 0;

                do
                {
                    Console.Write($"{i + 1}. nap erősségi szintje (1-től 5-ig): ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out level))
                    {
                        if (level >= 1 && level <= 5)
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("HIBA: Az erősségi szint 1 és 5 közötti egész számnak kell legyen.");
                            isValid = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("HIBA: Egész számot írj be.");
                        isValid = false;
                    }
                } while (!isValid);

                intensityLevels[i] = level;
            }

            // 3. Kiíratás

            double totalTrainingTime = 0.0;

            Console.WriteLine("\n\n Heti edzésterhelés számítása");

            for (int i = 0; i < trainingDays; i++)
            {

                double dailyTrainingTime = baseDuration * (1.0 + 0.1 * intensityLevels[i]);
                totalTrainingTime += dailyTrainingTime;

                Console.WriteLine($"- {i + 1}. nap (Erősség: {intensityLevels[i]}): {dailyTrainingTime:F2} perc");
            }


            double totalCaloriesBurned = weight * totalTrainingTime * calorieMultiplier;

            Console.WriteLine("\n ÖSSZEGZÉS");
            Console.WriteLine($"Felhasználó: {name}");
            Console.WriteLine($"Testsúly: {weight:F1} kg");
            Console.WriteLine($"Heti edzésnapok száma: {trainingDays}");
            Console.WriteLine($"Teljes heti edzésidő: {totalTrainingTime:F2} perc");
            Console.WriteLine($"Becsült elégetett kalória: {totalCaloriesBurned:F2} kcal");
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
