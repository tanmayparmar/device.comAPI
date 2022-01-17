using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace device.com.Models
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options)
    : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; } = null!;
    }
}
