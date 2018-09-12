using Carlos_Esquivel_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET.Utils
{
    public class ConsoleInterface 
    {
        public static string readWord()
        {
            
            Console.WriteLine("If you want to exit, press \"-x\" and enter");
            Console.WriteLine("To see all the words highlighted, press \"-all\" and enter");
            Console.WriteLine("To see the json representation of the word, type the word followed by \"-json\" and enter");
            Console.WriteLine("Please type the word to find in the word puzzle: ");
            string input = Console.ReadLine();
            return input;
           
        }

        public static void BadInputData()
        {
            Console.WriteLine("Bad input data");
            Console.WriteLine();
        }

        public static void PrintJson(List<WordClass> word)
        {

            Console.WriteLine(Util.GetJson(word));
            Console.WriteLine();

        }

        public static void Highligh(List<List<char>> puzzle, List<WordClass> word)
        {
            foreach (WordClass w in word)
            {
                foreach (LetterClass l in w.Letters)
                {
                    puzzle[l.Row][l.Column] = char.ToLower(puzzle[l.Row][l.Column]);
                }

            }
            
        }

        public static void PrintList(List<String> pList)
        {
            foreach (string val in pList)
            {
                Console.Write(val + " ");
            }
        }

        public static void PrintMatrix(List<List<char>> pMatrix, ConsoleColor backgroundColor)
        {
            
            foreach (List<char> chars in pMatrix)
            {
                foreach (char val in chars)
                {
                    if (char.IsLower(val))
                    {
                        Console.BackgroundColor = backgroundColor;
                    }
                    Console.Write(val + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }
        public static void PrintMatrix(List<String> pMatrix)
        {
            foreach (string val in pMatrix)
            {
                string parsedVal = String.Join(" ", val.Reverse());
                Console.WriteLine(parsedVal);
            }

        }

    }
}
