using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jClient;
using Database.Models;
using System.Collections.Generic;
using Database.Factories;
using System;

namespace learana_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAssertRepositoryInstance()
        {
            var _user = new User("kwilliams", "keith@webizly.com", "Keith", "Williams");
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

            var _records = Task.Run(async () =>
           {

               var _records = await User.RetrieveResults(_query);

               return _records;

           }).GetAwaiter().GetResult();

            ///Assert.IsInstanceOfType(_records, typeof(List<IRecord>));
        }



        private async Task mnu_ClickAsync(object sender, RoutedEventArgs e)
        {
            IDriver driver = GraphDatabase.Driver("neo4j://localhost:7687", AuthTokens.Basic("neo4j", "neo4j"));
            IAsyncSession session = driver.AsyncSession(o => o.WithDatabase("neo4j"));
            try
            {
                IResultCursor cursor = await session.RunAsync("CREATE (n) RETURN n");
                await cursor.ConsumeAsync();
            }
            finally
            {
                await session.CloseAsync();
            }

            await driver.CloseAsync();

            ///https://stackoverflow.com/questions/59581789/why-does-idriver-not-contain-a-definition-for-session-when-using-neo4j-in-c
            ///test
            /*[TestClass]
            {
                [TestMethod]
                {
                    System.Console.WriteLine();    
                }
            }*/
        }
    }
}
