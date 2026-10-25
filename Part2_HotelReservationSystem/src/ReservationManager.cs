namespace Part2_HotelReservationSystem.src;

public class RerservationManager
{
    private readonly List<Reservation> _reservations = [];

    public void CreateReservation(Reservation newReservation)
    {
        foreach(var existing in _reservations)
        {
            if(existing.Room.RoomNumber == newReservation.Room.RoomNumber &&
              existing.CheckInDate < newReservation.CheckOutDate && existing.CheckOutDate > newReservation.CheckInDate
              && existing.Status != Reservation.enStatus.Cancelled && existing.Status != Reservation.enStatus.CheckedOut)
            {
                throw new InvalidOperationException("This room is already booked.");
            }
        }

        _reservations.Add(newReservation);
    }
}