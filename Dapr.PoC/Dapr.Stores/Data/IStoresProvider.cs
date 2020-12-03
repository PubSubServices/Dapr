using System.Collections.Generic;
using Dapr.Common;

namespace Dapr.Stores.Data
{
    public interface IStoresProvider
    {
        Store GetStore(int storeId);
        IEnumerable<Store> GetStores();
    }
}