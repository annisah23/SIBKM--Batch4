using MVC.Models;

namespace MVC.Repositories.Interfaces;

public interface IRegionRepository
{
    List<Region> GetAll();
    Region GetById(int id);
    int Insert(Region region);
    int Update(Region region);
    int Delete(int id);
}
