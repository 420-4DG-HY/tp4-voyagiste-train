using CommonDataDTO;
using Microsoft.Extensions.Logging;
using TrainDAL;
using TrainDTO;

namespace TrainBLL
{
    public interface ITrainBusinessLogic
    {
        public Seat[] GetAvailableSeat();
        public TrainAvailability[] GetCarAvailabilities(Seat seat, TrainSchedule trainSchedule);
        public TrainBooking? GetTrainBooking(Guid TrainBookingId);
        public SeatType? GetSeatType(Guid SeatTypeId);
        public Seat? GetSeat(Guid SeatId);
        public TrainBooking Book(Guid CarId, DateTime From, DateTime To, Person rentedTo);

        public BookingConfirmation ConfirmBooking(TrainBooking carBooking);
        public BookingConfirmation? GetBookingConfirmation(TrainBooking carBooking);

        public BookingCancellation CancelBooking(TrainBooking carBooking);
        public BookingCancellation? GetBookingCancellation(TrainBooking carBooking);
    }
    
    //public class TrainBusinessLogic : ITrainBusinessLogic
    //{
    //    readonly ILogger<TrainBusinessLogic> _logger;
    //    //readonly ITrainDataAccess _dal;

    //    //public TrainBusinessLogic(ITrainDataAccess DataAccess, ILogger<TrainBusinessLogic> Logger)
    //    //{
    //    //    _dal = DataAccess;
    //    //    _logger = Logger;
    //    //}

    //    public TrainBooking Book(Guid CarId, DateTime From, DateTime To, Person rentedTo)
    //    {
    //        //Seat? car = _dal.GetCar(CarId);
    //        //if (car == null)
    //        //{
    //        //    string message = "Invalid Car GUID : " + CarId;
    //        //    _logger.LogError(message);
    //        //    throw new Exception(message);
    //        //}
    //        //return _dal.Book(car, From, To, rentedTo);
    //    }

    //    public BookingCancellation CancelBooking(TrainBooking cb)
    //    {
    //        // Libère la plage horaire de cette réservation
    //        _dal.AddCarAvailability(cb.Car, cb.From, cb.To);
    //        CleanupAvailabilities(cb.Car);

    //        return _dal.CancelBooking(cb);
    //    }

    //    void CleanupAvailabilities(Seat seat)
    //    {
    //        // ici on devrait éventuellement fusionner les disponibilités adjacentes
    //        // Une forme de défragmentation du calendrier après une annulation ou un retour prématuré de véhicule...

    //        TrainAvailability[]? availabilities = _dal.GetCarAvailabilities(seat);

    //        // On identifie les disponibilités adjacentes 
    //        // On les supprime et crée une nouvelle disponibilité qui les remplace
    //    }
    //}
}