using DataLibrary.DataAccess.Interfaces;
using DataLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace QUCC_Car.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/Car")]
    public class CarController : Controller
    {

        private readonly ICarDataAccess _carDataAccess;
        public CarController(ICarDataAccess carDataAccess)
        {
            _carDataAccess = carDataAccess;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            try
            {
                var carCollection = _carDataAccess.GetCars();

                return Ok(new ApiOkResponse(carCollection));
            }
            catch (Exception ex )
            {

                return BadRequest(new ApiResponse(400, ex.Message));
            }
          
        }

        [HttpGet("{carId}")]
        public IActionResult GetCarById(Guid carId)
        {
            try
            {
                var carModel = _carDataAccess.GetCarById(carId);
                return Ok(new ApiOkResponse(carModel));
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse(400, ex.Message));
            }
            
        }

        [HttpPost("")]
        public IActionResult AddCarDetails([FromBody] TblCar carModel)
        {
            try
            {
                if (carModel == null)
                {
                    return BadRequest(new ApiResponse(404));
                }

                var result = _carDataAccess.AddCar(carModel);

                return Ok(new ApiOkResponse(result));
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse(400, ex.Message));
            }
        }

        [HttpPut("")]
        public IActionResult UpdateCarDetails([FromBody] TblCar carModel)
        {
            try
            {
                if (carModel == null)
                {
                    return BadRequest(new ApiResponse(404));
                }

                var result = _carDataAccess.UpdateCar(carModel);

                return Ok(new ApiOkResponse(true));

            }
            catch (Exception ex )
            {

                return BadRequest(new ApiResponse(400, ex.Message));
            }
        }

        [HttpDelete("{carId}")]
        public IActionResult DeleteCar(Guid carId)
        {
            try
            {
                var result = _carDataAccess.DeleteCar(carId);

                return Ok(new ApiOkResponse(true));

            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse(400, ex.Message));
            }
        }
    }
}
