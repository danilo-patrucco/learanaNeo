using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;
using Neo4j.Driver;
using Database.Models;
using System.Collections.Generic;
using Database.Factories;

namespace learana_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAssertRepositoryInstance()
        {
            var _user = new User("kwilliams","keith@webizly.com","Keith","Williams");
            Assert.IsInstanceOfType(_user, typeof(User));
        }
        [TestMethod]
        public void TestAssertUserCreate()
        {
            var _user = User.Create("kwilliams", "keith@webizly.com", "Keith", "Williams");
            Assert.IsInstanceOfType(_user, typeof(User));
        }
        [TestMethod]

        public void TestAssertUserFactoryCreate()
        {
            var _user = UserFactory.CreateFakeUser();
            Assert.IsInstanceOfType(_user, typeof(User));
        }

        [TestMethod]
        public void TestAssertRetrieveResults()
        {

            var _query = "MATCH (n) RETURN n; ";

            var _records =  Task.Run(async () =>
            {
                
                var _records = await User.RetrieveResults(_query);

                return _records;

            }).GetAwaiter().GetResult();

            Assert.IsInstanceOfType(_records, typeof(List<IRecord>));
        }
    }
}
