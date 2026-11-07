using System;

namespace week02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Executing Mystery Stack Trace Evaluation");
            Console.WriteLine("========================================");

            // --- MysteryStack1 Verification ---
            Console.WriteLine("\n[Testing MysteryStack1: String Reversal]");
            Console.WriteLine($"racecar                  -> {MysteryStack1.Run("racecar")}");
            Console.WriteLine($"stressed                 -> {MysteryStack1.Run("stressed")}");
            Console.WriteLine($"a nut for a jar of tuna  -> {MysteryStack1.Run("a nut for a jar of tuna")}");

            // --- MysteryStack2 Verification ---
            Console.WriteLine("\n[Testing MysteryStack2: Postfix Evaluation]");
            Console.WriteLine($"5 3 7 + *          -> {MysteryStack2.Run("5 3 7 + *")}");
            Console.WriteLine($"6 2 + 5 3 - /      -> {MysteryStack2.Run("6 2 + 5 3 - /")}");

            // --- Exception Boundary Testing Execution ---
            Console.WriteLine("\n[Testing MysteryStack2: Exception Boundaries]");
            
            TryExpression("5 +", "Invalid Case 1");
            TryExpression("5 0 /", "Invalid Case 2");
            TryExpression("5 abc +", "Invalid Case 3");
            TryExpression("5 3", "Invalid Case 4");
        }

        private static void TryExpression(string expr, string label)
        {
            try
            {
                MysteryStack2.Run(expr);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"{label} Triggered Successfully with input '{expr}': {ex.Message}");
            }
        }
    }
}
