using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET.Models
{
    public class WordClass
    {
        public string Word { get; set; }
        public List<LetterClass> Letters { get; set; }

        [JsonIgnore]
        public string WordLetter {
            get
            {
                string lWord = string.Empty;
                if (this.Letters != null && this.Letters.Count() > 0)
                {
                    
                    foreach (LetterClass letter in this.Letters)
                    {
                        lWord += letter.Character;
                    }
                }
                return lWord;
            }
        }

        public WordClass()
        {
            this.Letters = new List<LetterClass>();
        }

    }
}
