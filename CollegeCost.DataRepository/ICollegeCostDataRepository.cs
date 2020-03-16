using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CollegeCost.DataRepositories.Entities;

namespace CollegeCost.DataRepositories
{
    public interface ICollegeCostDataRepository
    {
        Task<CollegeCostEntity> GetCollegeCostEntityAsync(string collegeName);
    }
}
