using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration.Common;
using Integration.Backend;

namespace Integration.Service
{
    public class ItemIntegrationService
    {
        // This is a dependency, normally fullfilled externally.
        private ItemOperationBackend ItemIntegrationBackend { get; set; }

        public ItemIntegrationService()
        {
            ItemIntegrationBackend = new ItemOperationBackend();
        }

        // This is called externally, and can be called multithreaded, in parallel.
        // More than one item with the same content should not be saved. However,
        // calling this with different contents at the same time is OK, and should
        // be allowed for performance reasons.
        public Result SaveItem(string itemContent)
        {
            // Check the backend to see if the content is already saved.

            if (ItemIntegrationBackend.FindItemsWithContent(itemContent).Count != 0)
            {
                return new Result(false, $"Duplicate item receied with content {itemContent}.");
            }

            Item item = ItemIntegrationBackend.SaveItem(itemContent);

            return new Result(true, $"Item with content {itemContent} saved with id {item.Id}");

        }

        public List<Item> GetAllItems()
        {
            return ItemIntegrationBackend.GetAllItems();
        }
    }
}
