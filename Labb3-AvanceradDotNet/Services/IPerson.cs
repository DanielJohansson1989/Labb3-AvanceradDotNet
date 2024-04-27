using Labb3Models;

namespace Labb3_AvanceradDotNet.Services
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<Person> GetPersonAndInterests(int id);
        Task<Person> GetPersonAndLinks(int id);
        Task<Person> Add(Person newPerson);
        Task<Person> Update(Person person);
        Task<Person> Delete(int id);
    }
}
