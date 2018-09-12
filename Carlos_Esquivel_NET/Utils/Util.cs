using Carlos_Esquivel_NET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET.Utils
{
    public static class Util
    {
        public static bool ValidateWord(string word, List<LetterClass> formedWord)
        {
            string formed = FormString(formedWord);
            return word.Equals(formed);
        }

        public static string FormString(List<LetterClass> formedWord)
        {
            string word = string.Empty;
            foreach (LetterClass letter in formedWord)
            {
                word += letter.Character;
            }
            return word;
        }

        public static List<WordClass> WordInList(List<WordClass> solution, string word)
        {
            return solution.Where(x => x.Word == word.ToUpper()).ToList();
        }

        public static void SolutionToUpper(List<List<char>> solution)
        {
            for(int i = 0; i < solution.Count();i++)
            {
                for(int j = 0; j < solution[0].Count();j++)
                {
                    solution[i][j] = char.ToUpper(solution[i][j]);
                }
            }
        }

        public static string GetJson(List<WordClass> solution)
        {
            return JsonConvert.SerializeObject(solution);
        }

        public static bool ValidateMatrix(List<List<char>> matrix)
        {
            bool isValid = true;
            int expectedRowCount = matrix[0].Count();
            foreach(List<char> row in matrix)
            {
                if (row.Count() != expectedRowCount)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

    }
}
