using Carlos_Esquivel_NET.Models;
using Carlos_Esquivel_NET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET
{
    public class WordPuzzle
    {

        private List<List<char>> puzzle = new List<List<char>>();
        private List<String> wordsToFind = new List<string>();
        private List<WordClass> solution = new List<WordClass>();
        private int numberOfRows;
        private int numberOfColumns;

        public WordPuzzle(List<List<char>> puzzle, List<string> words)
        {
            this.puzzle = puzzle;
            this.wordsToFind = words;
            this.numberOfRows = puzzle.Count();
            this.numberOfColumns = puzzle[0].Count;

        }

        public List<WordClass> solve()
        {
            foreach (string word in wordsToFind)
            {
                for (int i = 0; i < this.numberOfRows; i++)
                {
                    for (int j = 0; j < this.numberOfColumns; j++)
                    {
                        if (word[0] == puzzle[i][j])
                        {
                            LetterClass initialLetter = new LetterClass(word[0], i, j);
                            allSolutions(i, j, word, initialLetter);
                        }
                    }
                }
               
            }
            return this.solution;
        }

        private void allSolutions(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            solveUp(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveDown(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveLeft(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveRight(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveLeftUp(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveLeftDown(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveRightUp(initialRowPosition, initialColumnPosition, word, initialLetter);
            solveRightDown(initialRowPosition, initialColumnPosition, word, initialLetter);
        }

        private void solveUp(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, -1, 0, word, initialLetter);

        }

        private void solveDown(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, 1, 0, word, initialLetter);
        }

        private void solveLeft(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, 0, -1, word, initialLetter);
        }

        private void solveRight(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, 0, 1, word, initialLetter);
        }

        private void solveLeftUp(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, -1, -1, word, initialLetter);
        }

        private void solveRightUp(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, -1, 1, word, initialLetter);
        }

        private void solveLeftDown(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, 1, -1, word, initialLetter);
        }

        private void solveRightDown(int initialRowPosition, int initialColumnPosition, string word, LetterClass initialLetter)
        {
            wordDisplacement(initialRowPosition, initialColumnPosition, 1, 1, word, initialLetter);
        }

        private void wordDisplacement(int initialRowPosition, int initialColumnPosition, int despRow, int despCol, string word, LetterClass initialLetter)
        {
            List<LetterClass> positions = new List<LetterClass>();
            positions.Add(initialLetter);
            int r = initialRowPosition;
            int c = initialColumnPosition;
            for(int i = 1; i < word.Count();i++)
            {
                r += despRow;
                c += despCol;

                if (r >= 0 && c >= 0 && r < this.numberOfRows && c < this.numberOfColumns)
                {
                    positions.Add(new LetterClass(this.puzzle[r][c], r, c));
                }
            }
            addToSolution(positions, word);
        }

        private void addToSolution(List<LetterClass> positions, string word)
        {
            string formed = Util.FormString(positions);
            if (word.Equals(formed))
            {
                WordClass w = new WordClass();
                w.Word = word;
                w.Letters = positions;
                this.solution.Add(w);
            }
        }
    }
}
