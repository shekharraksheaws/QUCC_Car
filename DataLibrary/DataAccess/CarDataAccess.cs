using DataLibrary.DataAccess.Interfaces;
using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public class CarDataAccess : ICarDataAccess
    {
        private readonly IQuccContext _quccContext;
        public CarDataAccess(IQuccContext quccContext) 
        { 
            _quccContext = quccContext;
        }
        public Guid AddCar(TblCar tblCar)
        {
            tblCar.Id = Guid.NewGuid();
            _quccContext.TblCars.Add(tblCar);
            _quccContext.SaveChanges();
            return tblCar.Id;
        }

        public bool DeleteCar(Guid carId)
        {
            try
            {
                var carToDelete = _quccContext.TblCars.FirstOrDefault(x => x.Id == carId);
                if(carToDelete != null)
                {
                    _quccContext.TblCars.Remove(carToDelete);
                    _quccContext.SaveChanges();
                    return true;
                }
                return false;
                
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public TblCar GetCarById(Guid carId) => _quccContext.TblCars.FirstOrDefault(x => x.Id == carId);

        public ICollection<TblCar> GetCars()
        {
            return _quccContext.TblCars.ToList();
        }

        public bool UpdateCar(TblCar tblCar)
        {
            try
            {
                var dbEntity = _quccContext.TblCars.FirstOrDefault(x => x.Id == tblCar.Id);

                if (dbEntity != null)
                {
                    dbEntity.RegNo = tblCar.RegNo;
                    dbEntity.Brand = tblCar.Brand;
                    dbEntity.RegYear = tblCar.RegYear;
                    dbEntity.SourceType = tblCar.SourceType;
                    dbEntity.ScCode = tblCar.ScCode;
                    dbEntity.Make = tblCar.Make;
                    dbEntity.Model = tblCar.Model;
                    dbEntity.Colour = tblCar.Colour;
                    dbEntity.ModelYear = tblCar.ModelYear;
                    dbEntity.Mileage = tblCar.Mileage;
                    dbEntity.EngineNo = tblCar.EngineNo;
                    dbEntity.ChassisNo = tblCar.ChassisNo;
                    dbEntity.FuelType = tblCar.FuelType;
                    _quccContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
           
            return false;
        }
    }
}
