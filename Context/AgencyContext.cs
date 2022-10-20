﻿using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Context
{
    public class AgencyContext : DbContext
    {
        public DbSet<PacchettoViaggio> pacchettiViaggi { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-agency;Integrated Security=True");
        }

    }
}