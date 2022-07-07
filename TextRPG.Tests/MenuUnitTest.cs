
namespace TextRPG.Tests
{
    [TestClass]
    public class MenuUnitTest
    {
        Menu a;

        [TestInitialize]
        public void Initialize()
        {
            a = new Menu(null);
        }
        [TestCleanup]
        public void SwitchToBaseMenu()
        {
            a.User = null;
            a.CurChar = null;
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
        [RegSuccessData]
        public void RegistrationWithNameAndPassword(string name, string password)
        {
            List<User> list = new List<User>();
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Users).Returns(db);
            var actual = a.Registration(name, password, mockContext.Object);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [RegFailData]
        public void RegistrationFailed(string name, string password)
        {
            List<User> list = new List<User>();
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Users).Returns(db);
            Assert.ThrowsException<ArgumentNullException>(() => a.Registration(name, password, mockContext.Object));
        }

        [TestMethod]
        [AuthSuccessData]
        public void AuthSuccess(string name, string password, User find)
        {
            List<User> list = new List<User>();
            list.Add(find);
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Users).Returns(db);
            var actual = a.Autherization(name, password, mockContext.Object);
            Assert.AreEqual(name, actual.User.Name);
        }
        [TestMethod]
        [AuthFailExpectedData]
        public void AuthExpectedFail(string name, string password, User find)
        {
            List<User> list = new List<User>();
            list.Add(find);
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Users).Returns(db);
            var actual = a.Autherization(name, password, mockContext.Object);
            Assert.AreEqual(null, actual.User);
        }
        [TestMethod]
        [AuthExceptionData]
        public void AuthFailException(string name, string password, User find)
        {
            List<User> list = new List<User>();
            list.Add(find);
            var db = GetQueryableMockDbSet(list);
            var mockContext = new Mock<RPGContext>();
            mockContext.Setup(m => m.Users).Returns(db);
            Assert.ThrowsException<ArgumentNullException>(() => a.Autherization(name, password, mockContext.Object));
        }
        [TestMethod]
        [SelectCharacterData]
        public void SelectCharacter(Character b)
        {
            var actual = a.SetCharacter(b);
            Assert.AreEqual(b.Name, actual.CurChar.Name);
        }
    }
}