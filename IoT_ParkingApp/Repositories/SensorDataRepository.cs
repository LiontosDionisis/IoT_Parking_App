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
        public async Task<SensorData> AddSensorDataAsync(SensorData sensorData)
        {
            await _context.SensorData.AddAsync(sensorData);
            await _context.SaveChangesAsync();
            return sensorData;
        }

        public async Task<IEnumerable<SensorData>> GetAllDataAsync()
        {
            return await _context.SensorData.ToListAsync();
        }
    }
}
