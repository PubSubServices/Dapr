using System.Collections.Generic;
using Dapr.Common;

namespace Dapr.Savings.Models
{
    public class SavingsResponse
    {
        public Store Store { get; set; }

        public List<Saving> Savings { get; set; }
    }
}
