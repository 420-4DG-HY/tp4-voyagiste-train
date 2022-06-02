using CommonDataDTO;
using TrainDTO;

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
            //TODO __________ Implémenter _dal GetAvailableSeat
            throw new NotImplementedException();
        }

        public TrainAvailability[] GetSeatAvailabilities(Guid seatId)
        {
            //TODO __________ Implémenter _dal GetSeatAvailabilities
            throw new NotImplementedException();
        }
    }
}
