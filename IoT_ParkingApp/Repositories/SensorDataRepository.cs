using IoT_ParkingApp.Data;
using IoT_ParkingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace IoT_ParkingApp.Repositories
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly AppDbContext _context;

        public SensorDataRepository(AppDbContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// Adds sensor data to the database
        /// </summary>
        /// <param name="sensorData">Sensor data to insert to the database</param>
        /// <returns>Sensor data</returns>
        public async Task<SensorData> AddSensorDataAsync(SensorData sensorData)
        {
            await _context.SensorData.AddAsync(sensorData);
            await _context.SaveChangesAsync();
            return sensorData;
        }

        /// <summary>
        /// Fetches all sensor data from the database
        /// </summary>
        /// <returns>A collection of objects each representing sensor data</returns>
        public async Task<IEnumerable<SensorData>> GetAllDataAsync()
        {
            return await _context.SensorData.ToListAsync();
        }
    }
}
