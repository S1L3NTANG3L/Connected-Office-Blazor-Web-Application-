using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class CategoryModel
	{
        [Required]
        public Guid CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
	}
}
