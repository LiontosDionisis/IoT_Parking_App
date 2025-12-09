using IoT_ParkingApp.Model;
using IoT_ParkingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace IoT_ParkingApp.Controllers
{
    [ApiController]
    [Route("api/sensor-data")]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataService _sensorDataService;
        
        public SensorDataController(ISensorDataService sensorDataService)
        {
            _sensorDataService = sensorDataService;
        }

        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] SensorData sensorData)
        {
            try
            {
                var data = await _sensorDataService.AddSensorDataAsync(sensorData);
                return Ok(data);

            } catch (ArgumentException e)
            {
                return BadRequest(new { success = false, error = e.Message });

            } catch (Exception e)
            {
                return StatusCode(500, new {success = false, error = e.Message});
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSensorData()
        {
            try
            {
                var data = await _sensorDataService.GetAllSensorDataAsync();
                return Ok(data);

            } catch (Exception e)
            {
                return StatusCode(500, new { success = false, error = "An unexpexted error has occured", e.Message });
            }
        }
    }
}
