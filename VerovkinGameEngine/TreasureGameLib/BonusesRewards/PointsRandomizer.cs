using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public static class PointsRandomizer
    {
        private const int uniqueChance = 10;

        private static readonly int[] luckyNumbers;

        static PointsRandomizer()
        {
            luckyNumbers = GetLuckyNumbers();
        }

        private static int[] GetLuckyNumbers()
        {
            int[] numbers = new int[uniqueChance];
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int index = 0; index < uniqueChance; index++)
            {
                numbers[index] = rand.Next(101);
            }

            return numbers;
        }

        public static Point[] GetArray(int emptySpaces, UniquePointFactory uniqueFactory, CommonPointFactory commonFactory)
        {
            List<Point> items = new List<Point>();

            Random rand = new Random(DateTime.Now.Millisecond);

            for (int index = 0; index < emptySpaces; index++)
            {
                if (luckyNumbers.Contains(rand.Next(101)))
                {
                    items.Add(uniqueFactory.CreateSingle());
                }
                else
                {
                    items.Add(commonFactory.CreateSingle());
                }
            }

            return items.ToArray();
        }
    }
}
