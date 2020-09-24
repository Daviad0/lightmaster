using LightMasterMVVM.Models;
using LightMasterMVVM.Scripts;
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
        public DbSet<TBA_DB_Model> TBAMatches { get; set; }
        public DbSet<TabletInstance> TabletInstances { get; set; }
        public SwitchConfiguration configuration => new ConfigurationData().LoadData();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=" + configuration.Database.Address + ";Port="+ configuration.Database.Port.ToString() + ";Database="+ configuration.Database.DatabaseName + ";User Id="+ configuration.Database.Username +";Password="+ configuration.Database.Password + "");

    }
}
