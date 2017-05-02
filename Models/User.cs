using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FTDNA_Coding_Task.Models
{
	public class User
	{
		public int UserId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		List<Sample> Samples { get; set; }
	}
}