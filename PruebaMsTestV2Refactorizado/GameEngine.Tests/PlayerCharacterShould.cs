using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        /*Prueba con Numeros*/

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void SerInexpertoCuandoNuevo()
        {
            var player = new PlayerCharacter();

            Assert.IsTrue(player.IsNoob);
            //Assert.IsFalse(player.IsNoob);
        }

        
        [TestMethod]
        [TestCategory("Player Defaults")]
        public void NoTieneNombrePorDefecto()
        {
            var player = new PlayerCharacter();

            Assert.IsNull(player.Nickname);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void ValorPorDefectorSalud()
        {
            var player = new PlayerCharacter();

            Assert.AreEqual(100, player.Health);
        }

        [TestMethod]
        [TestCategory("Player Healt")]
        public void RecibirDaño()
        {
            var player = new PlayerCharacter();

            player.TakeDamage(22);

            Assert.AreEqual(78, player.Health);

        }

        [TestMethod]
        [TestCategory("Player Healt")]
        public void RecibirDaño2()
        {
            var player = new PlayerCharacter();

            player.TakeDamage(22);

            Assert.AreNotEqual(100, player.Health);

        }

        [TestMethod]
        [TestCategory("Player Healt")]
        public void RecibirCuracionCuandoDuerme()
        {
            var player = new PlayerCharacter();
            player.Sleep(); // +1-100

            Assert.IsTrue(player.Health >= 101 && player.Health <= 200);


        }


        /*       Pruebas Con Strings   */
        [TestMethod]
        public void NombreCompleto()
        {
            var player = new PlayerCharacter();
            player.FirstName = "David";
            player.LastName = "Hernandez";

            //Assert.AreEqual("david hernandez", player.FullName);
            //ignore case
            Assert.AreEqual("david hernandez", player.FullName, true);

        }

        [TestMethod]
        public void NombreCompletoIniciaConPrimerNombre()
        {
            var player = new PlayerCharacter();
            player.FirstName = "David";
            player.LastName = "Hernandez";
            //Assert.IsTrue(player.FullName.StartsWith(player.FirstName));
            StringAssert.StartsWith(player.FullName, player.FirstName);
        }

        [TestMethod]
        public void NombreCompletoTerminaConSegundoNombre()
        {
            var player = new PlayerCharacter();
            player.FirstName = "David";
            player.LastName = "Hernandez";

            StringAssert.EndsWith(player.FullName, player.LastName);
            StringAssert.EndsWith(player.FullName, "Hernandez");
        }

        [TestMethod]
        public void NombreCompletoContiene()
        {
            var player = new PlayerCharacter();
            player.FirstName = "David";
            player.LastName = "Hernandez";

            StringAssert.Contains(player.FullName, "nan");
        }

        [TestMethod]
        public void NombreCompletoRegEx()
        {
            var player = new PlayerCharacter();
            player.FirstName = "David";
            player.LastName = "Hernandez";
            StringAssert.Matches(player.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            //StringAssert.DoesNotMatch(player.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+") );
        }

        
        /*Prueba con Collections*/
        
        [TestMethod]
        public void TieneArcoLargo()
        {
            var player = new PlayerCharacter();

            // sirve para collecciones
            CollectionAssert.Contains(player.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NoTieneLaArma()
        {
            var player = new PlayerCharacter();
            CollectionAssert.DoesNotContain(player.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void ContieneArmasIniciales()
        {
            var player = new PlayerCharacter();

            var weaponsI = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };
            //mismo index tiene que estar el elemento
            CollectionAssert.AreEqual(weaponsI, player.Weapons);
        }

        [TestMethod]
        public void ContieneArmasInicialesDesordenadas()
        {
            var player = new PlayerCharacter();

            var weaponsI = new[]
            {
                "Short Sword",
                "Short Bow",
                "Long Bow",
            };
            //no importa el orden solo que tengo los elementos
            CollectionAssert.AreEquivalent(weaponsI, player.Weapons);
        }

        [TestMethod]
        public void ContieneArmasDuplicadas()
        {
            var player = new PlayerCharacter();

            //player.Weapons.Add("Short Sword");
            CollectionAssert.AllItemsAreUnique(player.Weapons);
        }

        [TestMethod]
        public void ContieneUnaEspada()
        {
            var player = new PlayerCharacter();
            Assert.IsTrue(player.Weapons.Any(w => w.Contains("Sword")));
        }

        [TestMethod]
        public void NoTieneArmasInicialesVacias()
        {
            var player = new PlayerCharacter();
            // si existe algun string en las lista asi "" dara error
            Assert.IsFalse(player.Weapons.Any(w => string.IsNullOrWhiteSpace(w)));

        }


        /*Prueba basada en datos
        Se usa cuando el metodo se ejecuta varias veces para comprobar su eficacia y sin necesidad de copiar y pegar el mismo metodo 2 veces    
        con datarow se agrega cada iteracion
         */

        [DataTestMethod]
        //[DynamicData(nameof(Damages))]
        //[DynamicData("Damages")]
        //[DynamicData("GetDamages",DynamicDataSourceType.Method)]
        //[DynamicData(nameof(DamageData.GetDamages),typeof(DamageData),DynamicDataSourceType.Method)] //llamar metodo desde otra clase
        [DynamicData(nameof(ExternalHealthDamageTestData.GetDataDamage),typeof(ExternalHealthDamageTestData))]
        //[DataRow(1,99)]
        //[DataRow(22,78)]
        //[DataRow(101,1)]
        //[DataRow(50,50)]
        public void TakeDamage(int damage , int healthExpected)
        {
            var player = new PlayerCharacter();

            player.TakeDamage(damage);

            Assert.AreEqual(healthExpected, player.Health);

        }

        /*para compartir datos y que no repita el codigo se usan datos dinamicos y se cambian los [DataRow]
         por [DynamicData(nameof(Damages))]  <- mas preciso
        [DynamicData("Damages")]
        */

        public static IEnumerable<object[]> Damages
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { 1,99 },
                    new object[] { 22,78},
                    new object[] { 101,1},
                    new object[] { 50, 50},
                    new object[] { 0, 100}
                };
            }
        }

        /*Para recibir datos de un metodo se usa esto
        [DynamicData("GetDamages",DynamicDataSourceType.Method)] hay que especificar si es metodo o parametro con el segundo parametro
         
         */

        //public static IEnumerable<object[]> GetDamages()
        //{
        //    return new List<object[]>
        //        {
        //            new object[] { 1,99 },
        //            new object[] { 22,78},
        //            new object[] { 101,1},
        //            new object[] { 50, 50},
        //            new object[] { 0, 100}
        //        };
        //}
    } 
 
}

