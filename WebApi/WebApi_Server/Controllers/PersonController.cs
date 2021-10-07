using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;
using WebApi_Server.Controllers.Repositories;

namespace WebApi_Server.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public ActionResult<IEnumerable<Person>> Get()
        {
            var people = PersonRepository.GetPeople();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var people = PersonRepository.GetPeople();
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            var people = PersonRepository.GetPeople().ToList();
            person.Id = GetNewId(people);
            people.Add(person);
            PersonRepository.StorePeople(people);
            return Ok();

        }

        private long GetNewId(IEnumerable<Person> people)
        {
            long newId = 0;
            foreach (var person in people)
            {
                if (newId < person.Id)
                {
                    newId = person.Id;
                }
            }
            return newId + 1;
        }
    }
}
