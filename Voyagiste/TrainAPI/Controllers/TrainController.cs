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
        public SeatType[] GetAvailableSeats()
        {
            return _bll.GetSeatType();
        }

        [HttpGet("TrainAvailabilities/{SeatTypeId}")]
        public TrainAvailability[] GetSeatAvailabilities(Guid SeatTypeId)
        {
            if(SeatTypeId != null)
            {
                SeatType? s = _bll.GetSeatType(SeatTypeId);
                if(s != null)
                {
                    return _bll.GetSeatTypeAvailabilities(s);
                }
            }
            return new List<TrainAvailability>().ToArray();

        }

        [HttpGet("Seat/{SeatId}")]
        public Seat? GetSeat(Guid SeatId)
        {
            return _bll.GetSeat(SeatId);
        }


        [HttpPost("Book")]
        public TrainBooking Book(Guid TrainAvailabilityId, Person Passenger)
        {
            return _bll.Book(TrainAvailabilityId, Passenger);
        }
    }
}
