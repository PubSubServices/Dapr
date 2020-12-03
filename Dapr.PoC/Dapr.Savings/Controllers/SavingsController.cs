using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Savings.Data;
using Dapr.Savings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dapr.Savings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly ISavingsProvider savingsProvider;
        private readonly ILogger<SavingsController> _logger;

        public SavingsController(ISavingsProvider savingsProvider, ILogger<SavingsController> logger)
        {
            this.savingsProvider = savingsProvider;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Saving> Get()
        {
            _logger.LogInformation("Savings request received");
            var savings = savingsProvider.GetSavings();
            _logger.LogInformation($"Returning {savings.Count()} savings");

            return savings;
        }
    }
}
