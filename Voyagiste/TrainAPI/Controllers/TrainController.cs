using CommonDataDTO;
using Microsoft.AspNetCore.Mvc;
using TrainBLL;
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
            return _bll.GetSeatAvailabilities(SeatGuid);
        }

        [HttpPost("Book")]
        public TrainBooking Book(Guid AvailabilityGuid, Person rentedTo)
        {
            return _bll.Book(AvailabilityGuid, rentedTo, DateTime.Now);
        }
    }
}
