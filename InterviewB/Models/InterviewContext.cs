using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace InterviewB.Models
{
    public class InterviewContext : DbContext
    {
        public InterviewContext() : base("InterviewConnectionString")
        {
        }

        public DbSet<BASIC_INFO> BASIC_INFO { get; set; }
        public DbSet<USER> USERS { get; set; }
        public DbSet<Student> Student { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}