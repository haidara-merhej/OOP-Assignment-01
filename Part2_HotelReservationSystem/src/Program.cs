using Part2_HotelReservationSystem.src;

RerservationManager manager = new RerservationManager();

try
{

    Guest guest = new Guest(1, "Ali Mohammed", "222-333-444");
    Room room = new Room("A101", Room.enRoomType.Single, 97.32m);
    
    Reservation reservation = new Reservation(1, new DateTime(2026, 10, 10), new DateTime(2026, 10, 13), room);

    manager.CreateReservation(reservation);

    guest.AddReservation(reservation);

    reservation.Confirm();

    reservation.CheckIn();

    reservation.CheckOut();

    Guest guest2 = new Guest(2, "Ahmed Hassan", "555-666-444");
    Reservation reservation2 = new Reservation(2, new DateTime(2026, 10, 11), new DateTime(2026, 10, 14), room);
    manager.CreateReservation(reservation2);

    guest.AddReservation(reservation2);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}