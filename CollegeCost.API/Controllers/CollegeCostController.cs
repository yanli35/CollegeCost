using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeCost.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeCost.Controllers
{
    [Route("api/Costs")]
    [ApiController]
    public class CollegeCostController : ControllerBase
    {
        private readonly ICollegeCostService _collegeCostService;

        public CollegeCostController(ICollegeCostService collegeCostService)
        {
            _collegeCostService = collegeCostService;
        }

        [HttpGet]
        [Route("{collegeName}")]
        public async Task<IActionResult> GetAsync(string collegeName, bool includeBoarding = true)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(collegeName))
                {
                    return BadRequest("Error: College name is required.");
                }
                var result = await _collegeCostService.GetCollegeCostResourceAsync(collegeName, includeBoarding);

                if (result == null)
                {
                    return NotFound("Error: College not found.");
                }

                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
