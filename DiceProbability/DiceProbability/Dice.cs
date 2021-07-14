using System;
using System.Collections.Generic;
using System.Text;

namespace DiceProbability
{
    public class Dice
    {
        public int NumberOfSides { get; set; }

        public List<int> Sides
        {
            get
            {
                int i = 1;
                List<int> allSides = new List<int>();

                while (i <= this.NumberOfSides)
                {
                    allSides.Add(i);
                    i++;
                }
                return allSides;
            }
        }

        public Dice(int sides)
        {
            this.NumberOfSides = sides;
        }
    }
}
