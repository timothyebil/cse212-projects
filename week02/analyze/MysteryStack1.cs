using System;
using System.Collections.Generic;

namespace week02
{
    public static class MysteryStack1
    {
        /// <summary>
        /// Reverses an input string using LIFO stack mechanics.
        /// </summary>
        public static string Run(string text)
        {
            // Use generic Stack<char> to avoid boxing overhead and match C# standards
            var stack = new Stack<char>();
            foreach (var letter in text)
                stack.Push(letter);

            var result = "";
            while (stack.Count > 0)
                result += stack.Pop();

            return result;
        }
    }
}
