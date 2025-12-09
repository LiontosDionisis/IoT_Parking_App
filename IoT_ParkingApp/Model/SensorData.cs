using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IoT_ParkingApp.Model
{
    public class SensorData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DevEui { get; set; }

        [Required]
        public string SensorId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public bool Occupied { get; set; }

   
        public byte[] RawData { get; set; }





    }
}
