using TrainDTO;
using CommonDataDTO;

namespace TrainDAL
{
    public class FakeData
    {
        // Utilisez des GUID statiques (fake) pour les distinguer
        // https://www.guidgenerator.com/online-guid-generator.aspx

        private static FakeData? Singleton;

        #region Données de références
        internal static readonly SeatType[] seatTypes =
        {
            new SeatType(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), "Allée", "Allée"),
            new SeatType(new Guid("7392596a-38ee-4f9f-9ebc-fe6d2ab5951a"), "Fenêtre", "Fenêtre"),
            new SeatType(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), "Sortie de secours", "Sortie de secours"),
            new SeatType(new Guid("6326ffa2-5603-459c-bb23-9f3abcd4668c"), "Siege", "Siege"),
            new SeatType(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), "Wagon", "Wagon"),
        };

        internal static readonly Seat[] seats =
        {
          new Seat(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), "1", seatTypes[0]),
          new Seat(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), "5", seatTypes[1]),
          new Seat(new Guid("ad83a50d-66f6-4a53-b6d3-05aca37c9d23"), "9", seatTypes[2]),
          new Seat(new Guid("1579ccdc-97a2-45ce-855d-53e738430384"), "14", seatTypes[3]),
          new Seat(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), "18", seatTypes[4]),
          new Seat(new Guid("ad83a50d-66f6-4a53-b6d3-05aca37c9d23"), "24", seatTypes[0]),
          new Seat(new Guid("b8f8f8e9-f8c9-4f0b-b8e8-f8f8f8f8f8f8"), "30", seatTypes[1]),
        };

        internal static readonly TrainOperator[] trainOperators =
        {
            new TrainOperator(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), "ViaRail"),
            new TrainOperator(new Guid("7392596a-38ee-4f9f-9ebc-fe6d2ab5951a"), "Amtrak"),
            new TrainOperator(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), "SNCF"),
            new TrainOperator(new Guid("6326ffa2-5603-459c-bb23-9f3abcd4668c"), "Shoo Shoo"),
            new TrainOperator(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), "Wizz"),
            new TrainOperator(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), "CN"),
        };

        internal static readonly Address[] addresses =
        {
            new Address(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), new Country("France"), new Region("Auvergne"), new City("Grenoble"), new PostalCode("38000"), "1 rue de la Paix"),
            new Address(new Guid("7392596a-38ee-4f9f-9ebc-fe6d2ab5951a"), new Country("France"), new Region("Paris"), new City("Paris"), new PostalCode("38001"), "4 rue principale"),
            new Address(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), new Country("United Kindoms"), new Region("Great Bretain"), new City("London"), new PostalCode("38002"), "1st street"),
            new Address(new Guid("6326ffa2-5603-459c-bb23-9f3abcd4668c"), new Country("United States of America"), new Region("New York"), new City("Manhattan"), new PostalCode("8"), "11th street"),
            new Address(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), new Country("Canada"), new Region("Québec"), new City("St-Hyacinthe"), new PostalCode("J2S 1H9"), "3000 Av. Boullé"),
            new Address(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), new Country("Canada"), new Region("Quebec"), new City("Sherbrooke"), new PostalCode("J1K 2R1"), "2500 Bd de l'Université"),
        };

        internal static readonly TrainStation[] trainStations =
        {
          new TrainStation(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), "Grenoble", addresses[0]),
          new TrainStation(new Guid("7392596a-38ee-4f9f-9ebc-fe6d2ab5951a"), "Paris", addresses[1]),
          new TrainStation(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), "London", addresses[2]),
          new TrainStation(new Guid("6326ffa2-5603-459c-bb23-9f3abcd4668c"), "Manhattan", addresses[3]),
          new TrainStation(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), "St-Hyacinthe", addresses[4]),
          new TrainStation(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), "Sherbrooke", addresses[5]),
        };

        internal static readonly TrainLine[] trainLines =
        {
          new TrainLine(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), "France", trainOperators[0], trainStations.Take(2).ToArray()),
          new TrainLine(new Guid("7392596a-38ee-4f9f-9ebc-fe6d2ab5951a"), "Europe", trainOperators[5], trainStations.Take(3).ToArray()),
          new TrainLine(new Guid("cb98eade-0d5a-4de3-8b8c-c3e9f95516a1"), "English", trainOperators[1], trainStations.Skip(2).Take(2).ToArray()),
          new TrainLine(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), "Éducation", trainOperators[2], trainStations.TakeLast(2).ToArray()),
        };

        internal static readonly DateTime[] dateTimes =
        {
            new DateTime(2019, 1, 1, 1, 0, 0),
            new DateTime(2019, 1, 1, 2, 0, 0),
            new DateTime(2019, 1, 1, 3, 0, 0),
            new DateTime(2019, 1, 1, 4, 0, 0),
            new DateTime(2019, 1, 1, 5, 0, 0),
            new DateTime(2019, 1, 1, 6, 0, 0),
            new DateTime(2019, 1, 1, 7, 0, 0),
            new DateTime(2019, 1, 1, 8, 0, 0),
            new DateTime(2019, 1, 1, 9, 0, 0),
            new DateTime(2019, 1, 1, 10, 0, 0),
            new DateTime(2019, 1, 1, 11, 0, 0),
            new DateTime(2019, 1, 1, 12, 0, 0),
            new DateTime(2019, 1, 1, 13, 0, 0),
            new DateTime(2019, 1, 1, 14, 0, 0),
            new DateTime(2019, 1, 1, 15, 0, 0),
            new DateTime(2019, 1, 1, 16, 0, 0),
            new DateTime(2019, 1, 1, 17, 0, 0),
            new DateTime(2019, 1, 1, 18, 0, 0),
            new DateTime(2019, 1, 1, 19, 0, 0),
            new DateTime(2019, 1, 1, 20, 0, 0),
        };

        internal static readonly TrainSchedule[] trainSchedules =
        {
            new TrainSchedule(new Guid("c100fa74-fdb5-42b8-b69a-cc5b5bc3a2ab"), trainLines[0].Name, trainLines[0], trainStations[0], trainStations[1], dateTimes.Take(2).ToArray()),
            new TrainSchedule(new Guid("7392596a-38ee-4f9f-9ebc-fe6d2ab5951a"), trainLines[0].Name, trainLines[0], trainStations[1], trainStations[0], dateTimes.Take(2).ToArray()),
            new TrainSchedule(new Guid("50580569-7d4f-436c-9e87-8579141a7913"), trainLines[1].Name, trainLines[1], trainStations[0], trainStations[2], dateTimes.Skip(2).Take(3).ToArray()),
            new TrainSchedule(new Guid("5fbecb9c-c29a-4019-9880-22cc868a06e2"), trainLines[1].Name, trainLines[1], trainStations[2], trainStations[0], dateTimes.Skip(2).Take(3).ToArray()),
            new TrainSchedule(new Guid("6326ffa2-5603-459c-bb23-9f3abcd4668c"), trainLines[2].Name, trainLines[2], trainStations[2], trainStations[3], dateTimes.Skip(5).Take(2).ToArray()),
            new TrainSchedule(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), trainLines[2].Name, trainLines[2], trainStations[3], trainStations[2], dateTimes.Skip(5).Take(2).ToArray()),
            new TrainSchedule(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), trainLines[3].Name, trainLines[3], trainStations[4], trainStations[5], dateTimes.Skip(7).Take(2).ToArray()),
            new TrainSchedule(new Guid("e72a802e-9e32-4efd-b52c-88f04005f493"), trainLines[3].Name, trainLines[3], trainStations[5], trainStations[4], dateTimes.Skip(7).Take(2).ToArray()),
        };
        #endregion

        #region Données dynamiques               
        internal List<TrainAvailability> trainAvailabilities;
        internal List<TrainBooking> trainBookings;
        internal List<BookingConfirmation> bookingConfirmations;
        internal List<BookingCancellation> bookingCancellations;
        internal List<Seat> Seats;
        #endregion

        public FakeData()
        {
            trainAvailabilities = new List<TrainAvailability>();
            trainAvailabilities.Add(new TrainAvailability(new Guid("56f93c48-0922-42d7-bddd-a3edd154685d"), trainSchedules[0], seats[0]));
            trainAvailabilities.Add(new TrainAvailability(new Guid("aceff190-c2cb-47a7-b773-a150173eb89f"), trainSchedules[2], seats[1]));
            trainAvailabilities.Add(new TrainAvailability(new Guid("10e9721a-2a9a-4d45-a86d-54dea2dce15b"), trainSchedules[4], seats[2]));
            trainAvailabilities.Add(new TrainAvailability(new Guid("2b11a5d9-5c88-4ea6-b097-cff7e4c5987c"), trainSchedules[6], seats[3]));

            trainBookings = new List<TrainBooking>();
            bookingConfirmations = new List<BookingConfirmation>();
            bookingCancellations = new List<BookingCancellation>();
        }

        internal static FakeData GetInstance()
        {
            if (Singleton is null) 
                Singleton = new FakeData();
            return Singleton;
        }
    }
}