using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Tests
{
    public class ExternalHealthDamageTestData
    {
        //ir a propiedades del archivos csv y darle en copiar si es posterior
        public static IEnumerable<object[]> GetDataDamage
        {
            get
            {
                String[] csv = File.ReadAllLines("DamageDataExternal.csv");
                var textCases = new List<object[]>();
                foreach (var csvLine in csv)
                {
                    IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);
                    object[] testCase = values.Cast<object>().ToArray();

                    textCases.Add(testCase);
                }

                return textCases;  


            }
        }
    }
}
