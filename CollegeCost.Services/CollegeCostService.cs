using System;
using System.Resources;
using System.Threading.Tasks;
using CollegeCost.Models;
using CollegeCost.DataRepositories;
using CollegeCost.DataRepositories.Entities;

namespace CollegeCost.Services
{
    public class CollegeCostService : ICollegeCostService
    {
        private readonly ICollegeCostDataRepository _collegeCostDataRepository;

        public CollegeCostService(ICollegeCostDataRepository collegeCostDataRepository)
        {
            _collegeCostDataRepository = collegeCostDataRepository;
        }

        public async Task<CollegeCostResource> GetCollegeCostResourceAsync(string collegeName, bool includeBoarding)
        {
            var entity = await _collegeCostDataRepository.GetCollegeCostEntityAsync(collegeName);

            return GetCollegeCostResource(entity, includeBoarding);
        }

        private CollegeCostResource GetCollegeCostResource(CollegeCostEntity entity, bool includeBoarding)
        {
            if (entity == null)
            {
                return null;
            }

            var result = new CollegeCostResource();

            if (includeBoarding)
            {
                result.CostInState = entity.RoomAndBoard + (entity.TuitionInState ?? 0);
                result.CostOutOfState = entity.RoomAndBoard + (entity.TuitionOutOfState ?? 0);
            }
            else
            {
                result.CostInState = entity.TuitionInState ?? 0;
                result.CostOutOfState = entity.TuitionOutOfState ?? 0;
            }

            return result;
        }
    }
}
