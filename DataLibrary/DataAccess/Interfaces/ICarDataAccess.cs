using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess.Interfaces
{
    public interface ICarDataAccess
    {
        public Guid AddCar(TblCar tblCar);

        public bool UpdateCar(TblCar tblCar);

        public bool DeleteCar(Guid carId);

        public ICollection<TblCar> GetCars();

        public TblCar GetCarById(Guid carId);
    }
}
