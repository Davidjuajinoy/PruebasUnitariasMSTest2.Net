using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace GameEngine.Tests
{
    public class PlayerDefaultAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] {"Player Defaults" };
    }
    public class PlayerSaludAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Healts" };
    }
}
