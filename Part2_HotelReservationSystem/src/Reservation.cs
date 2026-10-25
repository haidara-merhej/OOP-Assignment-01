using System.Runtime.CompilerServices;

namespace Part2_HotelReservationSystem.src;

public class Reservation
{
    public enum enStatus { Pending, Confirmed, CheckedIn, CheckedOut, Cancelled} 
    public int ReservationId { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public Room Room { get; }
    public enStatus Status { get; private set; }
    public decimal TotalCost => NumberOfNights() * Room.NightlyRate;

    public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
    {
        if(CheckInDate > CheckOutDate)
            throw new ArgumentException("Check-out date must be after check-in date.");

        if(room.IsUnderMaintenence)
            throw new ArgumentException("Room must not be under maintenence.");

        ReservationId = reservationId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
        Status = enStatus.Pending;
    }

    private int NumberOfNights()
    {
        return (CheckOutDate - CheckInDate).Days;
    }

    public void Confirm()
    {
        if(Status != enStatus.Pending)
            throw new InvalidOperationException($"Connot change reservation status from {Status} to {enStatus.Confirmed}");

        Status = enStatus.Confirmed;
    }

    public void Cancel()
    {
        if(Status != enStatus.Pending || Status != enStatus.Confirmed)
            throw new InvalidOperationException($"Connot change reservation status from {Status} to {enStatus.Cancelled}");

        Status = enStatus.Cancelled;
    }

    public void CheckIn()
    {
        if(Status != enStatus.Confirmed)
            throw new InvalidOperationException($"Connot change reservation status from {Status} to {enStatus.CheckedIn}");

        Status = enStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if(Status != enStatus.CheckedIn)
            throw new InvalidOperationException($"Connot change reservation status from {Status} to {enStatus.CheckedOut}");

        Status = enStatus.CheckedOut;
    }
}