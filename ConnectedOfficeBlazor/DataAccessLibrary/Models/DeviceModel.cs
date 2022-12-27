using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class DeviceModel
    {
		[Required]
		public Guid DeviceID { get; set; }
		[Required]
		public string DeviceName { get; set; }
		[Required]
		public Guid CategoryID { get; set; }
		[Required]
		public Guid ZoneID { get; set; }
		[Required]
		public bool IsActive { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public DateTime DateCreated { get; set; }
    }
}
