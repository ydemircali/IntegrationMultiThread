using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration.Common;
using Integration.Backend;
using System.Collections.Concurrent;

namespace Integration.Service
{
    public class ItemIntegrationService
    {
        private ConcurrentDictionary<string, string> SentItems { get; set; }
        // This is a dependency, normally fullfilled externally.
        private ItemOperationBackend ItemIntegrationBackend { get; set; }

        public ItemIntegrationService()
        {
            ItemIntegrationBackend = new ItemOperationBackend();
            SentItems = new ConcurrentDictionary<string, string>();
        }

        // This is called externally, and can be called multithreaded, in parallel.
        // More than one item with the same content should not be saved. However,
        // calling this with different contents at the same time is OK, and should
        // be allowed for performance reasons.
        public async Task<Result> SaveItem(string itemContent)
        {
            // Check the backend to see if the content is already saved.
            if (!SentItems.ContainsKey(itemContent) && SentItems.TryAdd(itemContent, itemContent))
            {
                Item item = ItemIntegrationBackend.SaveItem(itemContent);
                return new Result(true, $"Item with content {itemContent} saved with id {item.Id}");
            }
            else
            {
                return new Result(false, $"Duplicate item receied with content {itemContent}.");
            }

           

        }

        public List<Item> GetAllItems()
        {
            return ItemIntegrationBackend.GetAllItems();
        }
    }
}
