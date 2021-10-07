using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionGyak
{
    class Garage
    {
        private List<Car> _cars;

        public Garage()
        {
            _cars = new List<Car>();
        }

        //params tetszőleges számú argumentum itt int tömbként tárol
        public void Add(params Car[] items)
        {
            //add range tömböt is hozzá tudunk adni a listánkhoz
            _cars.AddRange(items);
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars;
        }
    }
}
