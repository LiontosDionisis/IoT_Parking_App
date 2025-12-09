using IoT_ParkingApp.Model;

namespace IoT_ParkingApp.Repositories
{
    public interface ISensorDataRepository
    {
        Task<SensorData> AddSensorDataAsync(SensorData sensorData);
        Task<IEnumerable<SensorData>> GetAllDataAsync(); 
    }
}
