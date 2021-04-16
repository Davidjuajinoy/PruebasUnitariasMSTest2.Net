using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Tests
{
    [TestClass]
    public class LifeCycle
    {
        static string SomeTestContext;

        //se ejecuta antes de cada ejecucion de la pruebas 
        [TestInitialize]
        public void lifeCycleInit()
        {
            Console.WriteLine("     Test inicializado LifeCycle");
           
        }

        //se ejecuta despues de cada ejecucion de la pruebas 
        [TestCleanup]
        public void lifeCycleClean()
        {
            Console.WriteLine("     Test CleanUp LifeCycle");
        }

        //se ejecuta primero que la primera prueba solo una vez
        [ClassInitialize]
        public static void LifeCycleClassInit(TestContext context)
        {   
            Console.WriteLine(" Class initialize LifeCycle");
            Console.WriteLine("Db cargada");
            SomeTestContext = "42";
        }

        //se ejecuta de ultimas que la ultima prueba solo una vez
        [ClassCleanup]
        public static void LifeCleanupClassInit()
        {
            Console.WriteLine(" Class CleanUp LifeCycle");
        }

        [TestMethod]
        public void pruebaA()
        {
            Console.WriteLine("Prueba A");
            Console.WriteLine($"la db esta compartida {SomeTestContext}");
        }

        [TestMethod]
        public void pruebaB()
        {
            Console.WriteLine("Prueba B");
            Console.WriteLine($"la db esta compartida {SomeTestContext}");
        }
    }
}
