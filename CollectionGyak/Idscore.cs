using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CollectionGyak
{
    class Idscore
    {
        private List<int> _ids;

        public Idscore()
        {
            _ids = new List<int>();
        }

        //params tetszőleges számú argumentum itt int tömbként tárol
        public void Add(params int[] items)
        {
            //add range tömböt is hozzá tudunk adni a listánkhoz
            _ids.AddRange(items);
        }

        public IEnumerable<int> GetAll()
        {
            return _ids;
        }
    }
}
