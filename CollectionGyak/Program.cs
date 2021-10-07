using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionGyak
{
    class Program
    {
        static void Main(string[] args)
        {
            //var idStore = new Idscore();
            //idStore.Add(5);
            //idStore.Add(34, 2, 34);
            //var stroreResult = idStore.GetAll();
            //foreach( var element in stroreResult)
            //{
            //    Console.WriteLine(element);
            //}
            //var garage = new Garage();
            //garage.Add(new Car("DMR-234"),new Car("HTG-840"));
            //var parkingCar = garage.GetAll();
            var idStore = new GenericsStore<int>();
            idStore.Add(5);
            idStore.Add(34, 2, 34);
            var stroreResult = idStore.GetAll();
            foreach( var element in stroreResult)
            {
                Console.WriteLine(element);
            }
            var garage = new GenericsStore<Car>();
            garage.Add(new Car("DMR-234"),new Car("HTG-840"));
            var parkingCar = garage.GetAll();

            IEnumerable<string> plates=parkingCar.Select(Car => Car.Rendszam);
            IEnumerable<Car> street = plates.Where(plate => plate == "DMR-234").Select(plate => new Car(plate));
        }
    }
}
