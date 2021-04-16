using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace GameEngine.Tests
{
    /*Crea metodos DinamycData especializados*/
    /// <summary>
    /// Atributo personalizado para leer un csv 
    /// </summary>
    public class CsvDataSourceAttribute : Attribute, ITestDataSource
    {
        public string FileName{ get;}

        public CsvDataSourceAttribute(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            String[] csv = File.ReadAllLines(FileName);
            var textCases = new List<object[]>();
            foreach (var csvLine in csv)
            {
                IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);
                object[] testCase = values.Cast<object>().ToArray();

                textCases.Add(testCase);
            }

            return textCases;
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data == null)  return null;
            return $"{methodInfo.Name}  ({string.Join(",", data)} ";  
        }
    }
}
