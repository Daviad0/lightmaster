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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=lightscoutx;Username=strategy_member;Password=strategy");
    }
}
