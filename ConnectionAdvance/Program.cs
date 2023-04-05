using MVC.Controllers;
using MVC.Models;
using MVC.Repositories;
using MVC.Views;

namespace MVC;

public class Program
{
    public static void Main()
    {
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Database Connectivity=========");
            Console.WriteLine("1. Manage Table Region");
            Console.WriteLine("2. Manage Table Country");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Region(); // Memanggil Method Region
                    break;
                case 2:
                    Country(); // Memanggil Method Country
                    break;
                case 3:
                    check = false; // Keluar dari Program
                    break;
                default:
                    // Jika Input Tidak Sesuai Program akan diulangi
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    // Mengakses Tabel Region
    public static void Region()
    {
        RegionController regionController = new RegionController(new RegionRepository(), new VRegion());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    // Memanggil Method GetAll dari Class RegionController
                    Console.Clear();
                    regionController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    // Memanggil Method GetById dari Class RegionController
                    Console.Clear();
                    Console.WriteLine("=======Get By Id Region========");
                    Console.Write("Input Id: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    regionController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    // Memanggil Method Insert dari Class RegionController
                    Console.Clear();
                    Console.WriteLine("=======Insert Region========");
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    regionController.Insert(new Region
                    {
                        Name = name
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    // Memanggil Method Update dari Class RegionController
                    Console.Clear();
                    Console.WriteLine("=======Update Region========");
                    Console.Write("Input Id: ");
                    var idUpdate = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Input Name: ");
                    var nameUpdate = Console.ReadLine();
                    regionController.Update(new Region
                    {
                        Id = idUpdate,
                        Name = nameUpdate
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    // Memanggil Method Delete dari Class RegionController
                    Console.Clear();
                    Console.WriteLine("=======Delete Region========");
                    Console.Write("Input Id: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    regionController.Delete(idDelete);
                    Console.ReadKey();
                    break;
                case 6:
                    // Keluar dari Method Region
                    check = false;
                    break;
                default:
                    // Jika Input Tidak Sesuai Program akan diulangi
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    // Mengakses Tabel Country
    public static void Country()
    {
        CountryController countryController = new CountryController(new CountryRepository(), new VCountry());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Country========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    // Memanggil Method GetAll dari Class CountryController
                    Console.Clear();
                    countryController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    // Memanggil Method GetById dari Class CountryController
                    Console.Clear();
                    Console.WriteLine("=======Get By Id Region========");
                    Console.Write("Input Id: ");
                    var id = Console.ReadLine();
                    countryController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    // Memanggil Method Insert dari Class CountryController
                    Console.Clear();
                    Console.WriteLine("=======Insert Region========");
                    Console.Write("Input Id: ");
                    var idIns = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Input Region Id: ");
                    var regionId = Convert.ToInt16(Console.ReadLine());
                    countryController.Insert(new Country
                    {
                        Id = idIns,
                        Name = name,
                        Region = regionId
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    // Memanggil Method Update dari Class CountryController
                    Console.Clear();
                    Console.WriteLine("=======Update Region========");
                    Console.Write("Input Id: ");
                    var idUpdate = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var nameUpdate = Console.ReadLine();
                    Console.Write("Input Id Region: ");
                    var regionUpdate = Convert.ToInt16(Console.ReadLine());
                    countryController.Update(new Country
                    {
                        Id = idUpdate,
                        Name = nameUpdate,
                        Region = regionUpdate
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    // Memanggil Method Delete dari Class CountryController
                    Console.Clear();
                    Console.WriteLine("=======Delete Region========");
                    Console.Write("Input Id: ");
                    var idDelete = Console.ReadLine();
                    countryController.Delete(idDelete);
                    Console.ReadKey();
                    break;
                case 6:
                    // Keluar dari Method Country
                    check = false;
                    break;
                default:
                    // Jika Input Tidak Sesuai Program akan diulangi
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

}
