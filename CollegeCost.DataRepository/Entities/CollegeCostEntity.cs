using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeCost.DataRepositories.Entities
{
    public class CollegeCostEntity
    {
        public string College { get; set; }
        public decimal? TuitionInState { get; set; }
        public decimal? TuitionOutOfState { get; set; }
        public decimal RoomAndBoard { get; set; }
    }
}
