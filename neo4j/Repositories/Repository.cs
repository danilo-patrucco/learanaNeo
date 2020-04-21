using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Database.Providers;

namespace Database.Repositories
{
    public interface IRepository
    {

    }

    public class Repository : IRepository
    {
        static neo4j Provider = new neo4j();

        public static async Task<List<IRecord>> RetrieveResults(string Query)
        {


            var _results = await Provider.queryExecute(Query);
           

            return _results;
                
        }
    }
}
