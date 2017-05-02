using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FTDNA_Coding_Task.Models
{
	public class Sample
	{
		public int SampleId { get; set; }

		public string Barcode { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CreatedById { get; set; }
		public User CreatedBy { get; set; }

		public int StatusId { get; set; }
		public Status Status { get; set; }

	}
}