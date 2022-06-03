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
        public TrainAvailability? GetTrainAvailability(Guid trainavailabilityId);

        // Dynamic Data (get and set)
        public TrainAvailability[] GetSeatAvailabilities(Seat seat); //*
        public TrainAvailability SetTrainAvailabilities(Seat seat, TrainSchedule trainSchedule);

        // Dynamic Data (get and set)
        public TrainBooking? GetTrainBooking(Guid TrainBookingId);

        public TrainBooking Book(Person Passenger, TrainAvailability Availability);

        public BookingCancellation CancelBooking(TrainBooking booking);
        public BookingCancellation? GetBookingCancellation(TrainBooking booking);

        public BookingConfirmation ConfirmBooking(TrainBooking booking);
        public BookingConfirmation? GetBookingConfirmation(TrainBooking booking);
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
            return FakeData.seats.Where(cb => cb.SeatId == SeatId).FirstOrDefault();
        }
        public SeatType? GetSeatType(Guid SeatTypeId)
        {
            throw new NotImplementedException();
        }

        public TrainBooking? GetTrainBooking(Guid TrainBookingId)
        {
            return FakeData.GetInstance().trainBookings.Where(cb => cb.TrainBookingId == TrainBookingId).FirstOrDefault();
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
        
        public TrainBooking Book(Person Passenger, TrainAvailability Availability)
        {
            var booking = new TrainBooking(new Guid(), Passenger, Availability, new DateTime());
            FakeData.GetInstance().trainBookings.Add(booking);
            return booking;
        }

        public Seat[] GetAvailableSeats()
        {
            var context = FakeData.GetInstance();
            Seat[] s = context.trainAvailabilities.Select(x => x.Seat).ToArray();
            return s;
        }

        public TrainAvailability[] GetSeatAvailabilities(Seat seat)
        {
            return FakeData.GetInstance().trainAvailabilities.Where(s => s.Seat == seat).ToArray();
        }

        public BookingCancellation CancelBooking(TrainBooking booking)
        {
            BookingCancellation bc = new BookingCancellation(new Guid(), booking, new DateTime());
            FakeData.GetInstance().bookingCancellations.Add(bc);
            return bc;  
        }

        public BookingConfirmation ConfirmBooking(TrainBooking booking)
        {
            BookingCancellation? bBancel = GetBookingCancellation(booking);
            if (bBancel != null)
            {
                string message = "Cannot confirm booking : \n" + booking + " \nBecause it has been cancelled by : \n" + bBancel;
                _logger.LogError(message);
                throw new Exception(message);
            }
            else
            {
                BookingConfirmation bc = new BookingConfirmation(new Guid(), booking, new DateTime());
                FakeData.GetInstance().bookingConfirmations.Add(bc);
                return bc;
            }
        }

        public BookingCancellation? GetBookingCancellation(TrainBooking booking)
        {
            return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }
        public BookingConfirmation? GetBookingConfirmation(TrainBooking booking)
        {
            return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public TrainAvailability? GetTrainAvailability( Guid trainavailabilityId)
        {
            return FakeData.GetInstance().trainAvailabilities.Where(t => t.TrainAvailabilityId == trainavailabilityId).FirstOrDefault();
        }
    }
}
