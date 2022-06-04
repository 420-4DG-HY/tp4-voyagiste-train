using CommonDataDTO;
using Microsoft.Extensions.Logging;
using TrainDAL;
using TrainDTO;

namespace TrainBLL
{
    public interface ITrainBusinessLogic
    {
        // Static Data (get only)
        //public Seat[] GetAvailableSeats();  //*
        public SeatType? GetSeatType(Guid SeatTypeId);
        public SeatType[] GetSeatType();

        public Seat? GetSeat(Guid seatid);

        // Dynamic Data (get and set)
        //public TrainAvailability[] GetSeatAvailabilities(Seat seat); //*
        public TrainAvailability[] GetSeatTypeAvailabilities(SeatType seatType); //*

        //public TrainBooking? GetTrainBooking(Guid TrainBookingId);
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

        public SeatType? GetSeatType(Guid SeatTypeId)
        {
            return _dal.GetSeatType(SeatTypeId);
        }
        public Seat? GetSeat(Guid seatid)
        {
            return _dal.GetSeat(seatid);
        }

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

        public TrainAvailability[] GetSeatTypeAvailabilities(SeatType seatType)
        {
            return _dal.GetSeatTypeAvailabilities(seatType);
        }

        public SeatType[] GetSeatType()
        {
           return _dal.GetSeatType();
        }

        #region Méthodes inutiles
        //public TrainBooking? GetTrainBooking(Guid TrainBookingId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Seat[] GetAvailableSeats()
        //{
        //    return _dal.GetAvailableSeats();
        //}

        //public TrainAvailability[] GetSeatAvailabilities(Seat seat)
        //{
        //    return _dal.GetSeatAvailabilities(seat);
        //}

        #endregion
    }
}