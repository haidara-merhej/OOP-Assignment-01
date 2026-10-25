namespace Part2_HotelReservationSystem.src;

public class Room
{
    public enum enRoomType { Single, Double, Suite};
    public string RoomNumber { get; } = null!;
    public enRoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenence { get; private set; }

    public Room(string roomNumber, enRoomType roomType, decimal nightlyRate)
    {
        if(nightlyRate <= 0)
            throw new ArgumentException($"{nameof(NightlyRate)} must be positive.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenence = false;
    }

    public void StartMaintenence()
    {
        IsUnderMaintenence = true;
    }

    public void EndMaintenence()
    {
        IsUnderMaintenence = false;
    }

    public void ChangeNightlyRate(decimal newRate)
    {
        if(newRate <= 0)
            throw new ArgumentException($"{nameof(NightlyRate)} must be positive.");
    }
}   