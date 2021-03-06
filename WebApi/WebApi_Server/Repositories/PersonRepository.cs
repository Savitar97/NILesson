using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace WebApi_Server.Controllers.Repositories
{
    public static class PersonRepository
    {
        private const string filename = "People.json";

        public static IEnumerable<Person> GetPeople() {

            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var people = JsonSerializer.Deserialize<IEnumerable<Person>>(rawData);
                return people;
            }
            return new List<Person>();
        }

        public static void StorePeople(IEnumerable<Person> people)
        {
            var rawData = JsonSerializer.Serialize(people);
            File.WriteAllText(filename, rawData);
        }
    }
}
