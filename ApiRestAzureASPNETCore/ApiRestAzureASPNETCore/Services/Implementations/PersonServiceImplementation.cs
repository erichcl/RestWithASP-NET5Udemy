using ApiRestAzureASPNETCore.Model;
using ApiRestAzureASPNETCore.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRestAzureASPNETCore.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;

        }

        public Person Create(Person person)
        {
            try {
                _context.Persons.Add(person);
                _context.SaveChanges();

            } 
            catch (Exception) {
                throw;
            }
            return person;
        }

        public void Delete(long Id)
        {
            Person? dbPerson = FindById(Id);
            if (dbPerson != null) {
                _context.Persons.Remove(dbPerson);
                _context.SaveChanges();
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));

        }

        public Person Update(Person person)
        {

            Person? dbPerson = FindById(person.Id);
            if (dbPerson == null) return new Person();
            try
            {

                _context.Entry(dbPerson).CurrentValues.SetValues(person);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
    }
}
