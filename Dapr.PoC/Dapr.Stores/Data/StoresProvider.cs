using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapr.Common;
using Newtonsoft.Json;

namespace Dapr.Stores.Data
{
    public class StoresProvider : IStoresProvider
    {
        private const string filePath = "./Data/Stores.json";

        public IEnumerable<Store> GetStores()
        {
            string json = File.ReadAllText(filePath);

            var stores = JsonConvert.DeserializeObject<List<Store>>(json);

            return stores;
        }


        public Store GetStore(int storeId)
        {
            var allStores = GetStores();
            return allStores.FirstOrDefault(str => str.Id == storeId);
        }
    }
}
