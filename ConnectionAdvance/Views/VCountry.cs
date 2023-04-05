using MVC.Models;

namespace MVC.Views;

public class VCountry
{
    // Menampilkan List Data Country
    public void GetAll(List<Country> countries)
    {
        foreach (var country in countries)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Id : " + country.Id);
            Console.WriteLine("Name : " + country.Name);
            Console.WriteLine("Region : " + country.Region);
        }
    }

    // Menampilkan Data Country Berdasarkan Id
    public void GetById(Country country)
    {
        Console.WriteLine("===================");
        Console.WriteLine("Id : " + country.Id);
        Console.WriteLine("Name : " + country.Name);
        Console.WriteLine("Region : " + country.Region);
    }

    // Menampilkan Pesan Sukses
    public void Success(string message)
    {
        Console.WriteLine($"Data has been {message}");
    }

    // Menampilkan Pesan Gagal
    public void Failure(string message)
    {
        Console.WriteLine($"Data has not been {message}");
    }

    // Menampilkan Pesan Data Tidak Ditemukan
    public void DataNotFound()
    {
        Console.WriteLine("Data Not Found");
    }
}
