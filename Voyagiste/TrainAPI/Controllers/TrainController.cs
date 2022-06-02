using CommonDataDTO;
using Microsoft.AspNetCore.Mvc;
using TrainBLL;
using TrainDAL;
using TrainDTO;

namespace TrainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainController : Controller
    {
        readonly ITrainBusinessLogic _bll;

        public TrainController(ITrainBusinessLogic BusinessLogic)
        {
            _bll = BusinessLogic;
        }

        [HttpGet("GetAvailableSeats")]
        public Seat[] GetAvailableSeats()
        {
            return _bll.GetAvailableSeats();
        }

        [HttpGet("TrainAvailabilities/{TrainLineGuid}")]
        public TrainAvailability[] GetSeatAvailabilities(Guid SeatGuid)
        {
            if (SeatGuid != null)
            {
                TrainAvailability[] cm = _bll.GetSeatAvailabilities(SeatGuid);
                if (cm != null)
                {
                    return cm;
                }
            }

            // Aucun résultat
            return new List<TrainAvailability>().ToArray();
        }

        [HttpPost("Book")]
        public TrainBooking Book(Guid AvailabilityGuid, Person rentedTo)
        {
            return _bll.Book(AvailabilityGuid, rentedTo, DateTime.Now);
        }
    }
}
