using device.com.Controllers;
using device.com.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace device.com.tests
{
    public class DeviceControllerTests
    {
        // This is just for demonstrate purpose. In real world we need to mock the data and mock the db context as well. I am here using sqlserver dbcontext.
        public DbContextOptions<DeviceContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=.;Database=device.com;Trusted_Connection=True;";


        [SetUp]
        public void Setup()
        {
            dbContextOptions = new DbContextOptionsBuilder<DeviceContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        [Test]
        public async Task GetDevicesShouldNotNull()
        {
            // Arrange
            using (var context = new DeviceContext(dbContextOptions))
            {
                DeviceController deviceController = new DeviceController(context);

                // Act
                var devices = await deviceController.GetDevices();

                //Assert
                Assert.IsNotNull(devices.Value);
            }
        }

        [Test]
        public async Task GetDeviceByIdShouldNotNull()
        {
            // Arrange
            using (var context = new DeviceContext(dbContextOptions))
            {
                DeviceController deviceController = new DeviceController(context);

                // Act
                var device = await deviceController.GetDevice(1);

                //Assert
                Assert.IsNotNull(device.Value);
                Assert.IsNotNull(device.Value.RelatedDevices);
            }
        }
    }
}