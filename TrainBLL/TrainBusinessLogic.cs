using CommonDataDTO;
using Microsoft.Extensions.Logging;
using TrainDAL;
using TrainDTO;

namespace TrainBLL
{
    public interface ITrainBusinessLogic
    {
        // Static Data (get only)
        public Seat[] GetAvailableSeats();  //*
        public SeatType? GetSeatType(Guid SeatTypeId);
        public Seat? GetSeat(Guid SeatId);

        // Dynamic Data (get and set)
        public TrainAvailability[] GetSeatAvailabilities(Seat seat); //*
        public TrainBooking? GetTrainBooking(Guid TrainBookingId);
        public TrainBooking Book(Guid TrainAvailabilityId, Person Passenger);





    }

    public class TrainBusinessLogic : ITrainBusinessLogic
    {
        readonly ILogger<TrainBusinessLogic> _logger;
        readonly ITrainDataAccess _dal;

        public TrainBusinessLogic(ITrainDataAccess DataAccess, ILogger<TrainBusinessLogic> Logger)
        {
            _dal = DataAccess;
            _logger = Logger;

        }

        #region Méthodes inutiles
        public SeatType? GetSeatType(Guid SeatTypeId)
        {
            throw new NotImplementedException();
        }
        public TrainBooking? GetTrainBooking(Guid TrainBookingId)
        {
            throw new NotImplementedException();
        }
        public Seat? GetSeat(Guid SeatId)
        {
            return _dal.GetSeat(SeatId);
        }
        #endregion

        public TrainBooking Book(Guid TrainAvailabilityId, Person Passenger)
        {
            TrainAvailability? TrainAvailability = _dal.GetTrainAvailability(TrainAvailabilityId);
            if (TrainAvailability == null)
            {
                string message = "Invalid Car GUID : " + TrainAvailabilityId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            return _dal.Book(Passenger, TrainAvailability);
        }

        public Seat[] GetAvailableSeats()
        {
            return _dal.GetAvailableSeats();
        }

        public TrainAvailability[] GetSeatAvailabilities(Seat seat)
        {
            return _dal.GetSeatAvailabilities(seat);
        }


    }
}