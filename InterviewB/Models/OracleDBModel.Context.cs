﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterviewB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InterviewContext : DbContext
    {
        public InterviewContext()
            : base("name=InterviewContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<USER> USERS { get; set; }
        public DbSet<BASIC_INFO> BASIC_INFO { get; set; }
        public DbSet<MEDICAL_DETAILS> MEDICAL_DETAILS { get; set; }
        public DbSet<MEDICAL_INFO> MEDICAL_INFO { get; set; }
        public DbSet<NAFSI_DETAILS> NAFSI_DETAILS { get; set; }
        public DbSet<NAFSI_INFO> NAFSI_INFO { get; set; }
        public DbSet<PARENTS_INFO> PARENTS_INFO { get; set; }
        public DbSet<RELATIVES_FOUR> RELATIVES_FOUR { get; set; }
        public DbSet<RELATIVES_ONE> RELATIVES_ONE { get; set; }
        public DbSet<RELATIVES_THREE> RELATIVES_THREE { get; set; }
        public DbSet<RELATIVES_TWO> RELATIVES_TWO { get; set; }
        public DbSet<SPORT_INFO> SPORT_INFO { get; set; }
    }
}
