using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Common;
using Dapr.Stores.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dapr.Stores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly IStoresProvider storesProvider;
        private readonly ILogger<StoresController> _logger;

        public StoresController(IStoresProvider storesProvider, ILogger<StoresController> logger)
        {
            this.storesProvider = storesProvider;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Store> Get()
        {
            _logger.LogInformation("Stores request received");
            var stores = storesProvider.GetStores();
            _logger.LogInformation($"Returning {stores.Count()} stores");

            return stores;
        }

        [Route("{id}")]
        [HttpGet]
        public Store GetStore(int id)
        {
            var store = storesProvider.GetStore(id);
            _logger.LogInformation($"Returning data for store #{id}");

            return store;
        }
    }
}
