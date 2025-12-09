using IoT_ParkingApp.DTOs;
using IoT_ParkingApp.Model;

namespace IoT_ParkingApp.Services
{
    public interface ISensorDataService
    {
        Task<SensorDataReadOnlyDTO> AddSensorDataAsync(SensorData sensorData);
        Task<IEnumerable<SensorDataReadOnlyDTO>> GetAllSensorDataAsync();
    }
}
