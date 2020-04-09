using System;
using System.Threading.Tasks;
using Neo4j;
using Neo4j.Driver;
using System.Collections.Generic;
using System.Collections;

namespace data
{
    public class neo4jProvider : IDisposable
    {
        static string _uri = "bolt://" + Settings.host + ":" + Settings.port + "/db/neo4j";

        static IDriver _driver;
         public  neo4jProvider()
        {

            _driver = GraphDatabase.Driver(_uri, AuthTokens.Basic(Settings.username, Settings.password));


        }
        public async Task<List<IRecord>> queryExecute(string query)
        {
           
            IAsyncSession session = _driver.AsyncSession();
            IResultCursor cursor = await session.RunAsync(query);
            
            var results = await cursor.ToListAsync();
            return results;
         
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
