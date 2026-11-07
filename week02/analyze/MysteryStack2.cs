using System;
using System.Collections.Generic;

namespace week02
{
    public static class MysteryStack2
    {
        private static bool IsFloat(string text)
        {
            return float.TryParse(text, out _);
        }

        /// <summary>
        /// Evaluates a Postfix (Reverse Polish Notation) expression using a stack wrapper.
        /// </summary>
        public static float Run(string text)
        {
            var stack = new Stack<float>();
            foreach (var item in text.Split(' '))
            {
                if (item == "+" || item == "-" || item == "*" || item == "/")
                {
                    if (stack.Count < 2)
                        throw new ApplicationException("Invalid Case 1!");

                    var op2 = stack.Pop();
                    var op1 = stack.Pop();
                    float res;
                    
                    if (item == "+")
                    {
                        res = op1 + op2;
                    }
                    else if (item == "-")
                    {
                        res = op1 - op2;
                    }
                    else if (item == "*")
                    {
                        res = op1 * op2;
                    }
                    else
                    {
                        if (op2 == 0)
                            throw new ApplicationException("Invalid Case 2!");

                        res = op1 / op2;
                    }

                    stack.Push(res);
                }
                else if (IsFloat(item))
                {
                    stack.Push(float.Parse(item));
                }
                else if (item == "")
                {
                    // Handle redundant whitespace spacing gracefully
                }
                else
                {
                    throw new ApplicationException("Invalid Case 3!");
                }
            }

            if (stack.Count != 1)
                throw new ApplicationException("Invalid Case 4!");

            return stack.Pop();
        }
    }
}
