using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace device.com.Models
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Temperature { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DeviceTypeId { get; set; }
        [ForeignKey(nameof(Id))]
        public IEnumerable<Device> RelatedDevices { get; set; }
    }
}
