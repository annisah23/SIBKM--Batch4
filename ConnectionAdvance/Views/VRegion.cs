using MVC.Models;

namespace MVC.Views;

public class VRegion
{
    // Menampilkan List Data Region
    public void GetAll(List<Region> regions)
    {
        foreach (var region in regions)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Id : " + region.Id);
            Console.WriteLine("Name : " + region.Name);
        }
    }

    // Menampilkan Data Region Berdasarkan Id
    public void GetById(Region region)
    {
        Console.WriteLine("===================");
        Console.WriteLine("Id : " + region.Id);
        Console.WriteLine("Name : " + region.Name);
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
