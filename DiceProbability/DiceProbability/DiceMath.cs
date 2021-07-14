using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceProbability
{
    public class DiceMath
    {
        public static Dictionary<int, int> GenerateDiceThing(List<List<int>> allDice)
        {
            //int diePlace = 0;
            //int dieSpace = 0;

            List<int> placeCounter = new List<int>();
            List<int> tempList = new List<int>();
            int tempInt = 0;
            Dictionary<int, int> finalSpread = new Dictionary<int, int>();

            foreach (List<int> i in allDice)
            {
                placeCounter.Add(0);
            }

            while (placeCounter[placeCounter.Count - 1] != 1)
            {

                for (int i = 0; i < allDice.Count - 1; i++)
                {
                    tempList.Add(allDice[i][placeCounter[i]]);
                }
                placeCounter = IncreaseCounter(placeCounter, allDice, 0);

                tempInt = tempList.Take(tempList.Count).Sum();


                if (!finalSpread.ContainsKey(tempInt))
                {
                    finalSpread[tempInt] = 1;
                }
                else
                {
                    finalSpread[tempInt] += 1;
                }
                tempList.Clear();
            }


            return finalSpread;
        }


        public static List<int> IncreaseCounter(List<int> counter, List<List<int>> allDice, int i)
        {
            if (i < counter.Count)
            {
                counter[i]++;

                if (counter[i] == allDice[i].Count)
                {
                    counter[i] = 0;
                    i++;

                    IncreaseCounter(counter, allDice, i);
                }
            }
            return counter;
        }

        public static int GetTotalCombinations(List<Dice> diceList)
        {
            int combinations = 1;
            
            for (int i = 0; i < diceList.Count -1; i++)
            {
                combinations *= diceList[i].NumberOfSides;
            }

            return combinations;
        }

        public static double CalculatePercentage(int totalCombinations, int currentCombinations)
        {
            return (double)(currentCombinations) / (double)(totalCombinations);
        }
    }
}
