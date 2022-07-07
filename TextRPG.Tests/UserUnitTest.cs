namespace TextRPG.Tests
{
    [TestClass]
    public class UserUnitTests
    {
        User a;
        [TestInitialize]
        public void Initialize()
        {
            a = new User("Template", "Template", new List<Character>());
        }
        [TestCleanup]
        public void Cleanup()
        {
            a.Characters = new List<Character>();
        }
        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }
        [TestMethod]
        [CreateSuccessData]
        public void CreateCharacterSuccess(string name, string gender, int expected)
        {
            List<Character> list = new List<Character>();
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Characters).Returns(db);
            var actual = a.CreateCharacter(name, gender, mockContext.Object);
            Assert.AreEqual(actual.Characters.Count(), expected);
        }
        [TestMethod]
        [CreateFailData]
        public void CreateCharacterException(string name, string gender)
        {
            List<Character> list = new List<Character>();
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Characters).Returns(db);

            Assert.ThrowsException<ArgumentException>(() => a.CreateCharacter(name, gender, mockContext.Object));
        }


    }
}