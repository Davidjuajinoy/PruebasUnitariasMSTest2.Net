using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Tests
{
    [TestClass]
    public class Assembly
    {
        [AssemblyInitialize] //antes de todas las pruebas solo 1 vez
        public static void AssemblyInit(TestContext context)
        {
            Console.WriteLine(" AseemblyInit");
        }

        [AssemblyCleanup] //de ultimas de todas las pruebas solo 1 vez
        public static void AssemblyClean()
        {
            Console.WriteLine(" AseemblyClean");
        }
    }
}