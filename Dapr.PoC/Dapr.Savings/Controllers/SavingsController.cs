using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapr.Client;
using Dapr.Common;
using Dapr.Savings.Data;
using Dapr.Savings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dapr.Savings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly DaprClient daprClient;
        private readonly ISavingsProvider savingsProvider;
        private readonly ILogger<SavingsController> _logger;        

        public SavingsController(ISavingsProvider savingsProvider, ILogger<SavingsController> logger)
        {
            this.daprClient = new DaprClientBuilder().Build();
            this.savingsProvider = savingsProvider;
            _logger = logger;
        }

        [HttpGet]
        [Route("{storeId}")]
        public async Task<SavingsResponse> Get(int storeId)
        {
            _logger.LogInformation($"Savings request received for store #{storeId}");

            var result = new SavingsResponse();
            result.Store = await GetStoreInformation(storeId);
            
            result.Savings = savingsProvider.GetSavings().ToList();
            _logger.LogInformation($"Returning {result.Savings.Count()} savings");

            return result;
        }

        private async Task<Store> GetStoreInformation(int storeId) {
            //_logger.LogInformation($"Fetching store #{storeId}");
            //var store = await daprClient.InvokeMethodAsync<Store>("stores", storeId.ToString());
            //_logger.LogInformation($"Retrieved {JsonConvert.SerializeObject(store)} for store #{storeId}");
            //return store;

            Store store = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:3500/v1.0/invoke/storesApp/method/stores/{storeId}");
                string content = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Store lookup response: {response.StatusCode} - {content}");

                if (response.IsSuccessStatusCode) {
                    store = JsonConvert.DeserializeObject<Store>(content);
                }
                
            }

            return store;
        }
    }
}
