using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class ZoneModel
	{
        [Required]
        public Guid ZoneID { get; set; }
        [Required]
        public string ZoneName { get; set; }
        [Required]
        public string ZoneDescription { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
	}
}
