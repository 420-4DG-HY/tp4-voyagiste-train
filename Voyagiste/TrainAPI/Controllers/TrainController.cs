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
        public TrainAvailability[] GetSeatAvailabilities(Seat seat)
        {
            return _bll.GetSeatAvailabilities(seat);
        }

        [HttpPost("Book")]
        public TrainBooking Book(Guid TrainAvailabilityId, Person Passenger)
        {
            return _bll.Book(TrainAvailabilityId, Passenger);
        }
    }
}
