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

        [HttpGet("TrainAvailabilities/{SeatId}")]
        public TrainAvailability[] GetSeatAvailabilities(Seat seat)
        {
            return _bll.GetSeatAvailabilities(seat);
        }

        [HttpGet("Seat/{SeatId}")]
        public Seat GetSeat(Guid seatid)
        {
            return _bll.GetSeat(seatid);
        }


        [HttpPost("Book")]
        public TrainBooking Book(Guid TrainAvailabilityId, Person Passenger)
        {
            return _bll.Book(TrainAvailabilityId, Passenger);
        }
    }
}
