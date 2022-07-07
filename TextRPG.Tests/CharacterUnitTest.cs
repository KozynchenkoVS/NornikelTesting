
namespace TextRPG.Tests
{
    [TestClass]
    public class CharacterUnitTest
    {
        [TestMethod]
        [AttackData]
        public void TestAttack(Character attacker, Character defender, int expected)
        {
            var actual = attacker.SwordAttack(defender);
            Assert.AreEqual(expected, actual);
        }
    }
}
