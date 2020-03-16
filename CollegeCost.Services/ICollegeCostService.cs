using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CollegeCost.Models;

namespace CollegeCost.Services
{
    public interface ICollegeCostService
    {
        Task<CollegeCostResource> GetCollegeCostResourceAsync(string collegeName, bool includeBoarding = true);
    }
}
