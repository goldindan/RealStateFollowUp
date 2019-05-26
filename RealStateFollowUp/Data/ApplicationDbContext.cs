using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealStateFollowUp.Models;

namespace RealStateFollowUp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<ClientRequestStatus> ClientRequestStatus { get; set; }
        public DbSet<MainDirection> MainDirection { get; set; }
        public DbSet<MasterBedroom> MasterBedroom { get; set; }

    }
}
