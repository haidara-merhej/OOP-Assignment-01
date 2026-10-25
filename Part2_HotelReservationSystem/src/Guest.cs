using Part2_HotelReservationSystem.src;

namespace Part2_HotelReservationSystem.src
{
    public class Guest
    { 
        private readonly List<Reservation> _reservations = []; 
        public int GuestId { get; }
        public string FullName { get; } = null!;
        public string PhoneNumber { get; } = null!;

        public IReadOnlyList<Reservation> Reservations => _reservations;
        public Guest(int guestId, string fullName, string phoneNumber)
        {
            if(string.IsNullOrEmpty(fullName))
                throw new ArgumentNullException(nameof(fullName));
            
            if(string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentNullException(phoneNumber);
                
            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public void AddReservation(Reservation reservation)
        {
            if(reservation is null)
                throw new ArgumentNullException(nameof(reservation));
                
            _reservations.Add(reservation);
        }
    }
}