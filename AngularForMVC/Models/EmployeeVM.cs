using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AngularForMVC.Models
{
	public class EmployeeVM
	{
		public int Id { get; set; }
		[Required]		// assists with (ModelState.IsValid)
		public string FullName { get; set; }
		[Required]		// assists with (ModelState.IsValid)
		[MinLength(5)]	// assists with (ModelState.IsValid)
		public string Notes { get; set; }
		public string Department { get; set; }
		public bool PerkCar { get; set; }
		public bool PerkStock { get; set; }
		public bool PerkSixWeeks { get; set; }
		public string PayrollType { get; set; }
	}
}