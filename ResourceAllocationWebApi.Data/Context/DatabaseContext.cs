using ResourceAllocationWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAllocationWebApi.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ResourceAllocationApp")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceAllocation> ResourceAllocations { get; set; }
    }
}
