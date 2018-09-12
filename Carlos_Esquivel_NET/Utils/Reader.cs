using Carlos_Esquivel_NET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Carlos_Esquivel_NET.Utils
{
    public static class Reader
    {
        /// <summary>
        /// Generic method to read any type of json file
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="readJson">is json file</param>
        /// <param name="fileName">name of the file to read</param>
        /// <returns>the in the form of the list type</returns>
        public static List<T> read<T>(bool readJson,string fileName)
        {
            try
            {
                List<T> vals = new List<T>();
                if (readJson)
                {
                    string json = readJsonFile(fileName);
                    vals = JsonConvert.DeserializeObject<List<T>>(json);
                }
                else
                {
                    //future imp
                }
                return vals;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static string readJsonFile(String name)
        {
            string json = string.Empty;
            using (StreamReader r = new StreamReader(name))
            {
                json = r.ReadToEnd(); 
            }
            return json;
        }
    }
}
