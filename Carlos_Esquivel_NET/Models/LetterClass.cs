using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET.Models
{
    /// <summary>
    /// Class for individual letters to serialize to a json
    /// </summary>
    public class LetterClass
    {
        public char Character { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public LetterClass(char character, int row, int column)
        {
            this.Character = character;
            this.Row = row;
            this.Column = column;
        }
        public LetterClass() { }
    }
}
