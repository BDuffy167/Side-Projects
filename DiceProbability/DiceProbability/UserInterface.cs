using System;
using System.Collections.Generic;
using System.Text;

namespace DiceProbability
{
    public class UserInterface
    {
        //private Dice die1;
        //private Dice die2;
        //private Dice die3;
        //private Dice die4;
        //private Dice die5;
        //private Dice die6;

        public void MainMenu()
        {
            List<Dice> diceList = new List<Dice>(); // { die1, die2, die3, die4, die4, die5, die6 };
            List<List<int>> allDice = new List<List<int>>(); //{ die1.Sides, die2.Sides, die3.Sides, die4.Sides, die5.Sides, die6.Sides };
            List<int> validDiceSize = new List<int>() { 3, 4, 6, 8, 10, 12, 20 };

            int currentDieToAdd = 0;

            while (currentDieToAdd < 6)
            {
                string userInput = GetMainMenuInput();

                if (int.TryParse(userInput, out int intValue))
                {
                    if (validDiceSize.Contains(intValue))
                    {
                        diceList.Add(new Dice(int.Parse(userInput)));
                        allDice.Add(diceList[currentDieToAdd].Sides);
                        currentDieToAdd++;
                        continue;
                    }

                }
                else if (userInput.ToLower() == "c")
                {
                    break;
                }
                Console.WriteLine("Please input a valid die size");
                Console.WriteLine();
            }
            diceList.Add(new Dice(2)); //Ghost die to prevent OutOfRange
            allDice.Add(diceList[currentDieToAdd].Sides);

            Dictionary<int, int> finalSpread = DiceMath.GenerateDiceThing(allDice);

            DisplayOutput(finalSpread, diceList);
        }

        public string GetMainMenuInput()
        {
            Console.WriteLine("Please input the number of sides of the die you would like to add (Max 6) or C to calculate");
            Console.WriteLine();

            Console.WriteLine("3) sided die");
            Console.WriteLine("4) sided die");
            Console.WriteLine("6) sided die");
            Console.WriteLine("8) sided die");
            Console.WriteLine("10) sided die");
            Console.WriteLine("12) sided die");
            Console.WriteLine("20) sided die");
            Console.WriteLine("C) to calculate");
            Console.WriteLine();

            string userInput = Console.ReadLine();
            Console.WriteLine();
            return userInput;
        }

        public void DisplayOutput(Dictionary<int, int> finalSpread, List<Dice> diceList)
        {
            int totalCombinations = DiceMath.GetTotalCombinations(diceList);
            int currentCombinations = totalCombinations;

            Console.WriteLine("The odds to roll:");
            Console.WriteLine();

            foreach (KeyValuePair<int, int> result in finalSpread)
            {
                double percentage = DiceMath.CalculatePercentage(totalCombinations, currentCombinations);

                string lineItem = string.Format($"At least {result.Key, -3} {percentage.ToString("P4"), 10}");

                currentCombinations -= result.Value;

                Console.WriteLine(lineItem);
            }


        }
    }
}
