using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class BossEnemyShould
    {
        //Numeros Doubles
        [TestMethod]
        public void AtkSpecialRight()
        {
            var boss = new BossEnemy();
            //son valores double , el tercer parametro es la especificacion de los decimales 
            Assert.AreEqual(166.6, boss.SpecialAttackPower, 0.07);

        }

    }
}
