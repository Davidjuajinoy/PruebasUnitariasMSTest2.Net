using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Tests
{
    public class DamageData
    {
        public static IEnumerable<object[]> GetDamages()
        {
           
            return new List<object[]>
                {
                    new object[] { 1,99 },
                    new object[] { 22,78},
                    new object[] { 101,1},
                    new object[] { 50, 50},
                    new object[] { 0, 100},
                    new object[] { 2, 98}
                };
        }
    }
}
