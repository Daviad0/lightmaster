using LightMasterMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightMasterMVVM.DbAssets
{
    public class ScoutingContext : DbContext
    {
        public DbSet<TeamMatch> Matches { get; set; }
        public DbSet<FRCTeamModel> FRCTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=lightscoutx;User Id=strategy_member;Password=strategy");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FRCTeamModel>().HasKey(f => new { f.team_number, f.event_key });
        }
    }
}
