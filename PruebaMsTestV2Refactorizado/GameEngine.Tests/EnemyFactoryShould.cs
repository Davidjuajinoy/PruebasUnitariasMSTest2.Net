using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Tests
{
    [TestClass]
    [TestCategory("Enemy Creation")]
    public class EnemyFactoryShould
    {
        /*Excepciones*/
        [TestMethod]
        //[Ignore]
        //[Ignore("No quiero que esta se ejecute")]
        public void NoPermiteNombreNull()
        {
            Console.WriteLine("Creando Instancia EnemyFactory");
            var enemy = new EnemyFactory();
            Console.WriteLine("Ejecutando metodo Create");
            Assert.ThrowsException<ArgumentNullException>( () => enemy.Create(null) );
        }

        [TestMethod]
        public void NombresPermitidosBoss()
        {
            var enemy = new EnemyFactory();

            //Assert.ThrowsException<EnemyCreationException>(() => enemy.Create("david",true));
            EnemyCreationException ex= Assert.ThrowsException<EnemyCreationException>(() => enemy.Create("david", true));

            //verificar si se puede usar un nombre;
            Assert.AreEqual("david", ex.RequestedEnemyName);
        }
    
        /*Tipo Objeto y referencia*/
        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            var enemy = new EnemyFactory();

            var zombie = enemy.Create("zombie");

            Assert.IsInstanceOfType(zombie, typeof(NormalEnemy));

            //afirma que la instancia no sea de normalEnemy
            //Assert.IsNotInstanceOfType(zombie, typeof(NormalEnemy));
        }

        [TestMethod]
        public void CreateBossEnemy()
        {
            var enemy = new EnemyFactory();
            var zombieBoss = enemy.Create("Zombie King",true);
            Assert.IsInstanceOfType(zombieBoss, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeparateInstances()
        {
            var enemyFactory = new EnemyFactory();

            var enemy1 = enemyFactory.Create("Zombie");
            var enemy2 = enemyFactory.Create("Zombie");
            //no apuntan a la misma referencia
            Assert.AreNotSame(enemy2, enemy1);
        }
    }
}
