using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using device.com.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace device.com.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceContext _context;

        public DeviceController(DeviceContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices
                .ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            // Finding related Devices by having same status
            device.RelatedDevices = await _context.Devices.Where(d => d.Status == device.Status).ToListAsync();

            return device;
        }
    }
}
