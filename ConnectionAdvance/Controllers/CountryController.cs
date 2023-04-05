using MVC.Models;
using MVC.Repositories.Interfaces;
using MVC.Views;

namespace MVC.Controllers;

public class CountryController
{
    private readonly ICountryRepository _countryRepository;
    private readonly VCountry _vCountry;

    public CountryController(ICountryRepository countryRepository, VCountry vCountry)
    {
        _countryRepository = countryRepository;
        _vCountry = vCountry;
    }

    // GET ALL
    public void GetAll()
    {
        var countries = _countryRepository.GetAll();
        if (countries == null)
        {
            _vCountry.DataNotFound();
        }
        _vCountry.GetAll(countries);
    }

    // GET BY ID
    public void GetById(string id)
    {
        var country = _countryRepository.GetById(id);
        if (country == null)
        {
            _vCountry.DataNotFound();
        }
        _vCountry.GetById(country);
    }

    // INSERT
    public void Insert(Country country)
    {
        var result = _countryRepository.Insert(country);
        if (result > 0)
        {
            _vCountry.Success("inserted");
        }
        else
        {
            _vCountry.Failure("insert");
        }
    }

    // UPDATE
    public void Update(Country country)
    {
        var result = _countryRepository.Update(country);
        if (result > 0)
        {
            _vCountry.Success("updated");
        }
        else
        {
            _vCountry.Failure("update");
        }
    }

    // DELETE
    public void Delete(string id)
    {
        var result = _countryRepository.Delete(id);
        if (result > 0)
        {
            _vCountry.Success("deleted");
        }
        else
        {
            _vCountry.Failure("delete");
        }
    }
}
