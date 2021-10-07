using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionGyak
{
    class GenericsStore<T>
    {
        private List<T> _items;

        public GenericsStore()
        {
            _items = new List<T>();
        }

        public void Add(params T[] items)
        {
            _items.AddRange(items);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }
    }
}
