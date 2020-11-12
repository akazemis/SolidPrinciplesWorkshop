using System;
using System.Collections.Generic;

namespace ISP.Examples.Example03
{
    public class DataStoreConsumer<TKey, TItem> where TItem : class
    {
        // Notice the use of the ITryFetch interface, which reduces the interface use
        // to what is actually required in this class
        private readonly ITryFetch<TKey, TItem> _dataStore = new DataStore<TKey,TItem>();

        public IEnumerable<TItem> FindItem(Func<TItem, bool> filter)
        {
            // Return all items that match the filter
            foreach (var key in _dataStore.Keys)
            {
                // Note: Does this example follow the interface segregation principle?
                // Why or why not?
                if (_dataStore.TryGet(key, out var currentItem) && filter(currentItem))
                {
                    yield return currentItem;
                }
            }
        }
    }
}