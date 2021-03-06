using firstapi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace firstapi.Controllers
{
    [Route("people")] // designate controller for "/people" endpoints
    public class PersonController
    {

        // declare property to hold Database Context
        private readonly PersonContext People;

        // define constructor to receive databse context via DI
        public PersonController(PersonContext people){
            People = people;
        }

        [HttpGet] // get request to "/people"
        public IEnumerable<Person> index(){
            // return all the people
            return People.Persons.ToList();
        }

        [HttpPost] // post request to "/people"
        public IEnumerable<Person> Post([FromBody]Person person){
            // add a person
            People.Persons.Add(person);
            // save changes
            People.SaveChanges();
            // return all the people
            return People.Persons.ToList();
        }

        [HttpGet("{id}")] // get requestion to "people/{id}"
        public Person show(long id){
            // return the specified person matched based on ID
            return People.Persons.FirstOrDefault(x => x.Id == id);
        }

        [HttpPut("{id}")] // put request to "people/{id}
        public IEnumerable<Person> update([FromBody]Person person, long id){
            // retrieve person to be updated
            Person oldPerson = People.Persons.FirstOrDefault(x => x.Id == id);
            //update their properties, can also be done with People.Persons.Update
            oldPerson.Name = person.Name;
            oldPerson.age = person.age;
            // Save changes
            People.SaveChanges();
            // return updated list of people
            return People.Persons.ToList();
        }

        [HttpDelete("{id}")] // delete request to "people/{id}
        public IEnumerable<Person> destroy(long id){
            //retrieve existing person
            Person oldPerson = People.Persons.FirstOrDefault(x => x.Id == id);
            //remove them
            People.Persons.Remove(oldPerson);
            // saves changes
            People.SaveChanges();
            // return updated list of people
            return People.Persons.ToList();
        }

    }
}