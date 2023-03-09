using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration.Common;

namespace Integration.Backend
{
    public class ItemOperationBackend
    {
        private ConcurrentBag<Item> SavedItems { get; set; }
        private int identitySequence = 0;

        public ItemOperationBackend()
        {
            SavedItems = new ConcurrentBag<Item>();
        }

        public Item SaveItem(string itemContent)
        {
            // This simulates how long it takes to save
            // the item content. Forty seconds, give or take.
            Thread.Sleep(2_000);

            Item item = new Item();
            item.Content = itemContent;
            item.Id = GetNextIdentity();
            SavedItems.Add(item);

            return item;
        }

        public List<Item> FindItemsWithContent(string itemContent)
        {
            return this.SavedItems.Where(x => x.Content == itemContent).ToList();
        }

        private int GetNextIdentity()
        {
            return Interlocked.Increment(ref identitySequence);
        }

        public List<Item> GetAllItems()
        {
            return this.SavedItems.ToList();
        }
    }
}
