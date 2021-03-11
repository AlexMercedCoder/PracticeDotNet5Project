using firstapi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace firstapi.Controllers
{
    [Route("people")]
    public class PersonController
    {
        private readonly PersonContext People;

        public PersonController(PersonContext people){
            People = people;
        }

        [HttpGet]
        public IEnumerable<Person> index(){
            return People.Persons.ToList();
        }

        [HttpPost]
        public IEnumerable<Person> Post([FromBody]Person person){
            People.Persons.Add(person);
            People.SaveChanges();
            return People.Persons.ToList();
        }

        [HttpGet("{id}")]
        public Person show(long id){
            return People.Persons.FirstOrDefault(x => x.Id == id);
        }

        [HttpPut("{id}")]
        public IEnumerable<Person> update([FromBody]Person person, long id){
            Person oldPerson = People.Persons.FirstOrDefault(x => x.Id == id);
            oldPerson.Name = person.Name;
            oldPerson.age = person.age;
            People.SaveChanges();
            return People.Persons.ToList();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Person> destroy(long id){
            Person oldPerson = People.Persons.FirstOrDefault(x => x.Id == id);
            People.Persons.Remove(oldPerson);
            People.SaveChanges();
            return People.Persons.ToList();
        }

    }
}