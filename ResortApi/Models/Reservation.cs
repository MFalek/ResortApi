//using System.Runtime.Serialization;

namespace ResortApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        public string? ClientName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
