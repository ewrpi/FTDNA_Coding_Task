using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FTDNA_Coding_Task.Models
{
	public class Status
	{
		public int StatusId { get; set; }
		public string StatusName { get; set; }

		public List<Sample> Samples { get; set; }
		
	}
}