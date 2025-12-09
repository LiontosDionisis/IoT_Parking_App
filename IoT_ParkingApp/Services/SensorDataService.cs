using IoT_ParkingApp.DTOs;
using IoT_ParkingApp.Model;
using IoT_ParkingApp.Repositories;

namespace IoT_ParkingApp.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataRepository _sensorDataRepo;

        public SensorDataService(ISensorDataRepository sensorDataRepo)
        {
            _sensorDataRepo = sensorDataRepo;
        }


        /// <summary>
        /// Adds a new sensor data entry and returns a readonly DTO
        /// </summary>
        /// <param name="sensorData">Sensor data to add</param>
        /// <returns>A DTO carrying the stored sensor data</returns>
        /// <exception cref="ArgumentException">Thrown if required fields are missing</exception>
        public async Task<SensorDataReadOnlyDTO> AddSensorDataAsync(SensorData sensorData)
        {
            if (string.IsNullOrWhiteSpace(sensorData.DevEui)) throw new ArgumentException("DevEui is required");
            if (string.IsNullOrWhiteSpace(sensorData.SensorId)) throw new ArgumentException("Sensor Id is required");
            if (sensorData.RawData == null || sensorData.RawData.Length == 0) throw new ArgumentException("RawData is required.");


            await _sensorDataRepo.AddSensorDataAsync(sensorData);

            return new SensorDataReadOnlyDTO
            {
                DevEui = sensorData.DevEui,
                SensorId = sensorData.SensorId,
                Timestamp = sensorData.Timestamp,
                Occupied = sensorData.Occupied,
            };

        }

        /// <summary>
        /// Fetches all sensor data from the database
        /// </summary>
        /// <returns>A collection of objects each representing a sensor data entry without exposing the rawData</returns>
        public async Task<IEnumerable<SensorDataReadOnlyDTO>> GetAllSensorDataAsync()
        {
            var dataToReturn = await _sensorDataRepo.GetAllDataAsync();
            return dataToReturn.Select(s => new SensorDataReadOnlyDTO
            {
                DevEui = s.DevEui,
                SensorId = s.SensorId,
                Timestamp = s.Timestamp,
                Occupied = s.Occupied,
            });
        }
    }
}
