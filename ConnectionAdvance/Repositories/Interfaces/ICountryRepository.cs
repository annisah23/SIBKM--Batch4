using MVC.Models;

namespace MVC.Repositories.Interfaces;

public interface ICountryRepository
{
        List<Country> GetAll();
        Country GetById(string id);
        int Insert(Country country);
        int Update(Country country);
        int Delete(string id);
}
