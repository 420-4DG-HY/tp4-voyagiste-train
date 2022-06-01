using Microsoft.AspNetCore.Mvc;
using TrainDTO;

namespace TrainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainController : Controller
    {
        readonly ILogger<TrainController> _logger;
        //readonly ITrainBusinessLogic _bll;

        public TrainController(/*ITrainBusinessLogic BusinessLogic,*/ ILogger<TrainController> Logger)
        {
            //_bll = BusinessLogic;
            _logger = Logger;
        }

        [HttpGet("GetAvailableSeats")]
        public TrainLine[] GetAvailableTrainLines()
        {
            
        }

        [HttpGet("TrainAvailabilities/{TrainLineGuid}")]
        public TrainAvailability[] GetTrainAvailabilities(Guid TrainLineGuid)
        {
            
        }


    }
}
