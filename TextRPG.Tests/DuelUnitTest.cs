namespace TextRPG.Tests
{
    [TestClass]
    public class DuelUnitTest
    {
        [TestMethod]
        [DuelData]
        public void TestDuel(Character attacker, Character defender, int turns, int expectedHealth)
        {
            Duel test = new Duel(attacker, defender, turns);
            Assert.AreEqual(expectedHealth, test.BeginDuel());
        }
    }
}
