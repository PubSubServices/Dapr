using System.Collections.Generic;
using Dapr.Savings.Models;

namespace Dapr.Savings.Data
{
    public interface ISavingsProvider
    {
        IEnumerable<Saving> GetSavings();
    }
}