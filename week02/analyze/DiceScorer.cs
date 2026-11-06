using System;
using System.Collections.Generic;

namespace analyze
{
    public class DiceScorer
    {
        public static Dictionary<int, int> GetCounts(int[] d)
        {
            var counts = new Dictionary<int, int>();
            foreach (var die in d)
            {
                if (counts.ContainsKey(die))
                {
                    counts[die]++;
                }
                else
                {
                    counts[die] = 1;
                }
            }
            return counts;
        }

        public static int CalculateScore(Dictionary<int, int> counts)
        {
            int score = 0;
            foreach (var kvp in counts.Values)
            {
                switch (kvp)
                {
                    case 2: score += 10; break;
                    case 3: score += 20; break;
                    case 4: score += 30; break;
                    case 5: score += 40; break;
                }
            }
            return score;
        }

        public static void RunVerification()
        {
            Console.WriteLine("\n======================\nDice Scorer Review\n======================");
            int[] testDice = { 2, 2, 3, 3, 3 };
            Array.Sort(testDice);
            Console.WriteLine("Values: " + string.Join(", ", testDice));
            
            var counts = GetCounts(testDice);
            int total = CalculateScore(counts);
            Console.WriteLine("Total: " + total);
        }
    }
}
