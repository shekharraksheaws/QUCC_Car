using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Model
{
    public interface IQuccContext
    {
        int SaveChanges();
        DbSet<TblCar> TblCars { get; set; }

    }
}