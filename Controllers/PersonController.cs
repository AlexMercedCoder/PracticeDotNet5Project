using firstapi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace firstapi.Controllers
{
   public class PersonController
    {
        private readonly PersonContext People;

        public PersonController(PersonContext people){
            People = people;
        }

        public IEnumerable<Person> index(){
            return People.Persons.ToList();
        }

        public IEnumerable<Person> Post([FromBody]Person person){
            People.Persons.Add(person);
            People.SaveChanges();
            return People.Persons.ToList();
        }

    }
}