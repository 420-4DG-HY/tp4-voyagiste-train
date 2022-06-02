using CommonDataDTO;
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
        public TrainAvailability[] GetSeatAvailabilities(Guid seatId); //*
        public TrainBooking? GetTrainBooking(Guid TrainBookingId);
        public TrainBooking Book(Guid availabilityGuid, Person rentedTo, DateTime now); //*
    }

    public class TrainBusinessLogic : ITrainBusinessLogic
    {
        readonly ITrainDataAccess _dal;

        public TrainBusinessLogic(ITrainDataAccess DataAccess)
        {
            _dal = DataAccess;
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
            throw new NotImplementedException();
        }
        #endregion

        public TrainBooking Book(Guid availabilityGuid, Person rentedTo, DateTime now)
        {
            return _dal.Book(availabilityGuid, rentedTo, now);
        }

        public Seat[] GetAvailableSeats()
        {
            return _dal.GetAvailableSeats();
        }

        public TrainAvailability[] GetSeatAvailabilities(Guid seatId)
        {
            return _dal.GetSeatAvailabilities(seatId);
        }

    }
}