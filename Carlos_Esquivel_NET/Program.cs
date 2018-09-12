using Carlos_Esquivel_NET.Models;
using Carlos_Esquivel_NET.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET
{
    class Program
    {
        private const string outKey = "-x";
        private const string allValues = "-all";
        private const string jsonRep = "-json";
        public static void Main(string[] args)
        {
            List<BaseClass> baseInfo = Reader.read<BaseClass>(true, ConfigurationManager.AppSettings["base"]);
            List<List<ValueClass>> valuesInfo = Reader.read<List<ValueClass>>(true, ConfigurationManager.AppSettings["values"]);
            List<String> cypher = Reader.read<String>(true, ConfigurationManager.AppSettings["cypher"]);
            List<String> words = Reader.read<String>(true, ConfigurationManager.AppSettings["words"]);

            Markov m = new Markov(baseInfo, valuesInfo, cypher);
            List<List<char>> wordPuzzle = m.calculate();

            if (Util.ValidateMatrix(wordPuzzle))
            {
                WordPuzzle puzzle = new WordPuzzle(wordPuzzle, words);
                List<WordClass> solution = puzzle.solve();
                Writer.WriteJsonSolution(solution);
                bool finish = false;
                ConsoleInterface console = new ConsoleInterface();
                ConsoleInterface.Highligh(wordPuzzle, solution);
                ConsoleInterface.PrintMatrix(wordPuzzle, ConsoleColor.DarkBlue);
                Console.WriteLine();
                while (!finish)
                {
                    string input = ConsoleInterface.readWord();
                    List<WordClass> word = Util.WordInList(solution, input);
                    if (input.ToLower().Equals(outKey))
                    {
                        finish = true;
                    }
                    bool allValue = input.ToLower().Equals(allValues);
                    bool jsonPrint = input.ToLower().Contains(jsonRep);
                    if (allValue)
                    {
                        ConsoleInterface.Highligh(wordPuzzle, solution);
                        ConsoleInterface.PrintMatrix(wordPuzzle, ConsoleColor.DarkBlue);
                    }
                    if (jsonPrint)
                    {
                        input = input.Split(' ').ToList().First().ToString();
                        word = Util.WordInList(solution, input);
                        if (word.Count() > 0)
                        {
                            ConsoleInterface.PrintJson(word);
                        }
                    }
                    if (word.Count() > 0 && !allValue && !jsonPrint)
                    {
                        Util.SolutionToUpper(wordPuzzle);
                        ConsoleInterface.Highligh(wordPuzzle, word);
                        ConsoleInterface.PrintMatrix(wordPuzzle, ConsoleColor.DarkYellow);
                    }
                    if (word.Count() == 0)
                    {
                        Console.WriteLine("Word not found");
                        Console.WriteLine();
                    }
                }
            }
            else {
                ConsoleInterface.BadInputData();
            }
        }
    }
}
