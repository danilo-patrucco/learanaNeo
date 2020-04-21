using System;
using System.Threading.Tasks;
using Neo4j.Driver;
using System.Collections.Generic;
using Database.Providers.Configuration;

namespace Database.Providers
{
    public class neo4j : IDisposable
    {
        static string uri = "bolt://" + Settings.Host + ":" + Settings.Port + "/db/neo4j";

        static IDriver driver = GraphDatabase.Driver(uri, AuthTokens.Basic(Settings.Username, Settings.Password));
        static IAsyncSession session = driver.AsyncSession();

        public async Task<List<IRecord>> queryRead(string query)
        {
            List<IRecord> _records = null;

            try
            {
                _records = await session.ReadTransactionAsync(async tx =>
                 {

                     // Send cypher query to the database
                     var _reader = await tx.RunAsync(query);

                     List<IRecord> _records = await _reader.ToListAsync();

              
                     return _records;
                 });
                     
            } catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            
            finally
            {
                // asynchronously close session
                await session.CloseAsync();
            }


            return _records;
        }
        public async Task<List<IRecord>> queryExecute(string query, object parameters = null)
        {
            List<IRecord> _records = null;

            try
            {
                _records = await session.ReadTransactionAsync(async tx =>
                {

                    // Send cypher query to the database
                    var _reader = await tx.RunAsync(query, parameters);

                    List<IRecord> _records = await _reader.ToListAsync();


                    return _records;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            finally
            {
                // asynchronously close session
                await session.CloseAsync();
            }

            return _records;
        }
        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}


