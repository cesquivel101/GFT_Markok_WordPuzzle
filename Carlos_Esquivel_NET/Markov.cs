using Carlos_Esquivel_NET.Models;
using Carlos_Esquivel_NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET
{
    public class Markov
    {
        private List<BaseClass> baseInfo;
        private List<List<ValueClass>> valuesInfo;
        private List<String> cypher;

        public Markov(List<BaseClass> baseInfo, List<List<ValueClass>> valuesInfo, List<String> cypher)
        {
            this.baseInfo = baseInfo;
            this.valuesInfo = valuesInfo;
            this.cypher = cypher;
        }

        public List<List<char>> calculate()
        {
            List<String> textGrid = new List<string>();
            textGrid = cypher;
            for(int j = 0; j < this.valuesInfo.Count();j++)
            {
                List<ValueClass> indexedRules = this.valuesInfo[j].OrderBy(p => p.Order).ToList();
                for (int i = 0; i < indexedRules.Count(); i++)
                {
                    bool isTermination = indexedRules[i].IsTermination;
                    string originalVal = this.baseInfo[indexedRules[i].Rule].Source;
                    string replaceVal = this.baseInfo[indexedRules[i].Rule].Replacement;

                    textGrid[j] = this.cypher[j].Replace(originalVal, replaceVal);
                    if (isTermination)
                    {
                        i = indexedRules.Count;
                    }

                }
            }

            List<List<char>> resultMatrix = convertToMatrix(textGrid);
            return resultMatrix;
        }

        private List<List<char>> convertToMatrix(List<String> textGrid)
        {
            List<List<char>> matrix = new List<List<char>>();
            foreach(string chars in textGrid)
            {
                matrix.Add(chars.ToCharArray().ToList());
            }
            return matrix;
        }
    }
}
