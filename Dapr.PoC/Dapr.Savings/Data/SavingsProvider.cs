using System.Collections.Generic;
using System.IO;
using Dapr.Savings.Models;
using Newtonsoft.Json;

namespace Dapr.Savings.Data
{
    public class SavingsProvider : ISavingsProvider
    {
        private const string filePath = "./Data/Savings.json";

        public IEnumerable<Saving> GetSavings()
        {
            string json = File.ReadAllText(filePath);

            var savings = JsonConvert.DeserializeObject<List<Saving>>(json);

            return savings;
        }
    }
}
