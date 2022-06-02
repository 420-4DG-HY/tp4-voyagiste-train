using TrainDTO;
using CommonDataDTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TrainDAL
{
    public interface ITrainDataAccess
    {
        // Static Data (get only)
        public Seat[] GetAvailableSeats();  //*
        public SeatType? GetSeatType(Guid SeatTypeId);
        public Seat? GetSeat(Guid SeatId);
        public TrainSchedule? GetTrainSchedule(Guid SeatId);

        // Dynamic Data (get and set)
        public TrainAvailability[] GetSeatAvailabilities(Guid seatId); //*
        public TrainAvailability SetTrainAvailabilities(Seat seat, TrainSchedule trainSchedule);

        // Dynamic Data (get and set)
        public TrainBooking? GetTrainBooking(Guid TrainBookingId);
        public TrainBooking Book(Guid availabilityGuid, Person rentedTo, DateTime now); //*
    }

    
    public class TrainDataAccess : ITrainDataAccess
    {
        private IConfiguration _configuration;
        private ILogger _logger;

        public TrainDataAccess(IConfiguration configuration, ILogger<TrainDataAccess> logger)
        {
            _configuration = configuration; // Permet éventuellement de recevoir ici la connexion string pour la base de données
            _logger = logger;
        }
        
        #region Méthodes inutiles
        public Seat? GetSeat(Guid SeatId)
        {
            throw new NotImplementedException();
        }
        public SeatType? GetSeatType(Guid SeatTypeId)
        {
            throw new NotImplementedException();
        }

        public TrainBooking? GetTrainBooking(Guid TrainBookingId)
        {
            throw new NotImplementedException();
        }

        public TrainSchedule? GetTrainSchedule(Guid SeatId)
        {
            throw new NotImplementedException();
        }

        public TrainAvailability SetTrainAvailabilities(Seat seat, TrainSchedule trainSchedule)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        public TrainBooking Book(Guid availabilityGuid, Person rentedTo, DateTime now)
        {
            //TODO __________ Implémenter _dal Book
            throw new NotImplementedException();
        }

        public Seat[] GetAvailableSeats()
        {
            var context = FakeData.GetInstance();
            Seat[] s = context.trainAvailabilities.Select(x => x.Seat).ToArray();

            return s;
            
            //return FakeData.GetInstance().trainAvailabilities.Select(x => x.Seat).ToArray();
        }

        public TrainAvailability[] GetSeatAvailabilities(Guid seatId)
        {
            //TODO __________ Implémenter _dal GetSeatAvailabilities
            throw new NotImplementedException();
        }
    }
}
