using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkProgram
{
    public class Store
    {
        public List<string> Items { get; set; }

        public Store(List<string> items)
        {
            Items = items;
        }

        public int ItemsCount()
        {
            var itemsInStore = Items.Count;
            return itemsInStore;
        }

        public void AddItem(string product)
        {
            if (product.GetType().Name != "String")
            {
                throw new NotSupportedException();
            }
            Items.Add(product);
        }

        public string GetAllProducts()
        {
            return string.Join(",", Items);
        }
    }
}
