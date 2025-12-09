namespace IoT_ParkingApp.DTOs
{
    public class SensorDataReadOnlyDTO
    {
        public string DevEui { get; set; }
        public string SensorId { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Occupied { get; set; }

        
    }
}
