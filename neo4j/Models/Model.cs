using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Database.Providers;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{

    public interface IModel
    {

    }

    public class Model : IModel
    {
        static neo4j Provider = new neo4j();
        protected bool NewRecord = true;
        [Display(Order = -15, Prompt = "Generated Unique ID", Description = "Generated Unique ID")]
        public Guid GUID = Guid.NewGuid();
        [Display(Order = -14, Prompt = "Record Created", Description = "Record Created")]
        public DateTime Created { get; set; }
        [Display(Order = -14, Prompt = "Record Updated", Description = "Record Updated")]
        public DateTime Updated { get; set; }

        public static async Task<List<IRecord>> RetrieveResults(string Query)
        {

            var _results = await Provider.queryExecute(Query);


            return _results;

        }
    }
}
