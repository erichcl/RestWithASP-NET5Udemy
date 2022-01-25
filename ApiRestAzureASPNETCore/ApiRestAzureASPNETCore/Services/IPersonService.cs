using ApiRestAzureASPNETCore.Model;
using System.Collections.Generic;

namespace ApiRestAzureASPNETCore.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);

        void Delete(long Id);
    }
}
