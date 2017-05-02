using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FTDNA_Coding_Task.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<Sample> Samples { get; set; }
	}
}