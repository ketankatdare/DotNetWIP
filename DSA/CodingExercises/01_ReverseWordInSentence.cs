using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    public class _01_ReverseWordInSentence
    {
        /// <summary>
        /// The function should not use any built-in functions to reverse the string.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string ReverseWords(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return sentence;
            }

            Stack<string> stack = new Stack<string>();
            StringBuilder word = new StringBuilder();

            foreach (char c in sentence)
            {
                if (c == ' ')
                {
                    if (word.Length > 0)
                    {
                        stack.Push(word.ToString());
                        word.Clear();
                    }
                }
                else
                {
                    word.Append(c); 
                }
            }

            if (word.Length > 0)
            {
                stack.Push(word.ToString());
                word.Clear();
            }

            return string.Join(" ", stack);
        }
    }
}
