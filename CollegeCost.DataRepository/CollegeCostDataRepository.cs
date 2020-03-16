using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CollegeCost.DataRepositories;
using CollegeCost.DataRepositories.Entities;
using Newtonsoft.Json;

namespace CollegeCost.DataRepositories
{
    public class CollegeCostDataRepository : ICollegeCostDataRepository
    {
        public async Task<CollegeCostEntity> GetCollegeCostEntityAsync(string collegeName)
        {
            return await Task.FromResult(DataCollection.FirstOrDefault(d => d.College.ToUpper() == collegeName.ToUpper()));
        }

        private static IEnumerable<CollegeCostEntity> _dataCollection = null;
        private static IEnumerable<CollegeCostEntity> DataCollection =>
            _dataCollection ?? (_dataCollection =
                JsonConvert.DeserializeObject<IEnumerable<CollegeCostEntity>>(File.ReadAllText(@".\collegecost.json")));
    }
}
