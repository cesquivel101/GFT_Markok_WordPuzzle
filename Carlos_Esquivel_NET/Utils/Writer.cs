using Carlos_Esquivel_NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos_Esquivel_NET.Utils
{
    public static class Writer
    {
        public static void WriteJsonSolution(List<WordClass> solution)
        {
            string solutionFileName = ConfigurationManager.AppSettings["solution"];
            string json = Util.GetJson(solution);
            File.WriteAllText(solutionFileName,json);
        }
    }
}
