using DemoLibrary.Models;

namespace DemoLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<PersonModel> GEtPeople();
        PersonModel InsertPerson(string firstName, string lastName);
    }
}