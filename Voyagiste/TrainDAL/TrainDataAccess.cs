using TrainDTO;
using CommonDataDTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TrainDAL
{
    public interface ITrainDataAccess
    {
        public SeatType? GetSeatType(Guid SeatTypeId);
        public SeatType[] GetSeatType();
        public Seat? GetSeat(Guid seatid);
        public TrainAvailability? GetTrainAvailability(Guid trainavailabilityId);
        public TrainAvailability[] GetSeatTypeAvailabilities(SeatType seatType);
        public TrainBooking Book(Person Passenger, TrainAvailability Availability);

        #region Methodes Inutiles
        //public Seat[] GetAvailableSeats();  //*
        //public TrainSchedule? GetTrainSchedule(Guid SeatId);
        //public TrainAvailability[] GetSeatAvailabilities(Seat seat); //*
        //public TrainAvailability SetTrainAvailabilities(Seat seat, TrainSchedule trainSchedule);
        //public TrainBooking? GetTrainBooking(Guid TrainBookingId);
        //public BookingCancellation CancelBooking(TrainBooking booking);
        //public BookingCancellation? GetBookingCancellation(TrainBooking booking);
        //public BookingConfirmation ConfirmBooking(TrainBooking booking);
        //public BookingConfirmation? GetBookingConfirmation(TrainBooking booking);
        #endregion
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
        public Seat? GetSeat(Guid seatid)
        {
            return FakeData.seats.Where(s => s.SeatId == seatid).FirstOrDefault();
        }

        public SeatType? GetSeatType(Guid SeatTypeId)
        {
            return FakeData.seatTypes.Where(cm => cm.SeatTypeId == SeatTypeId).FirstOrDefault();
        }
        
        public TrainBooking Book(Person Passenger, TrainAvailability Availability)
        {
            var booking = new TrainBooking(new Guid(), Passenger, Availability, new DateTime());
            FakeData.GetInstance().trainBookings.Add(booking);
            return booking;
        }

        public TrainAvailability? GetTrainAvailability(Guid trainavailabilityId)
        {
            var f = FakeData.GetInstance().trainAvailabilities.Where(t => t.TrainAvailabilityId == trainavailabilityId).FirstOrDefault();
            return f;
        }

        public TrainAvailability[] GetSeatTypeAvailabilities(SeatType seatType)
        {
            return FakeData.GetInstance().trainAvailabilities.Where(s => s.Seat.SeatType == seatType).ToArray();
        }

        public SeatType[] GetSeatType()
        {
            return FakeData.seats.Select(cm => cm.SeatType).Distinct().ToArray();
        }

        #region Méthodes inutiles

        //public TrainBooking? GetTrainBooking(Guid TrainBookingId)
        //{
        //    return FakeData.GetInstance().trainBookings.Where(cb => cb.TrainBookingId == TrainBookingId).FirstOrDefault();
        //}

        //public TrainSchedule? GetTrainSchedule(Guid SeatId)
        //{
        //    throw new NotImplementedException();
        //}

        //public TrainAvailability SetTrainAvailabilities(Seat seat, TrainSchedule trainSchedule)
        //{
        //    throw new NotImplementedException();
        //}
        //public Seat[] GetAvailableSeats()
        //{
        //    var context = FakeData.GetInstance();
        //    Seat[] s = context.trainAvailabilities.Select(x => x.Seat).ToArray();
        //    return s;
        //}

        //public TrainAvailability[] GetSeatAvailabilities(Seat seat)
        //{
        //    var f = FakeData.GetInstance().trainAvailabilities.Where(s => s.Seat == seat).ToArray();
        //    return f;
        //}

        //public BookingCancellation CancelBooking(TrainBooking booking)
        //{
        //    BookingCancellation bc = new BookingCancellation(new Guid(), booking, new DateTime());
        //    FakeData.GetInstance().bookingCancellations.Add(bc);
        //    return bc;  
        //}

        //public BookingConfirmation ConfirmBooking(TrainBooking booking)
        //{
        //    BookingCancellation? bBancel = GetBookingCancellation(booking);
        //    if (bBancel != null)
        //    {
        //        string message = "Cannot confirm booking : \n" + booking + " \nBecause it has been cancelled by : \n" + bBancel;
        //        _logger.LogError(message);
        //        throw new Exception(message);
        //    }
        //    else
        //    {
        //        BookingConfirmation bc = new BookingConfirmation(new Guid(), booking, new DateTime());
        //        FakeData.GetInstance().bookingConfirmations.Add(bc);
        //        return bc;
        //    }
        //}

        //public BookingCancellation? GetBookingCancellation(TrainBooking booking)
        //{
        //    return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        //}
        //public BookingConfirmation? GetBookingConfirmation(TrainBooking booking)
        //{
        //    return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        //}
        #endregion
    }
}
