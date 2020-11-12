using System;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace Common.Data
{
    public class DbContextHelper
    {
        public void EnsureEmptyDb(string dbConn, Action<DbContextOptionsBuilder, string> setupAction)
        {
            using (var dbContext = new AutoCreateEmptyDbContext(dbConn, setupAction))
            {
                if (!dbContext.Database.CanConnect())
                {
                    dbContext.Database.EnsureCreated();
                }
            }
        }

        public static DbContextHelper Instance = new DbContextHelper();
    }

    internal class AutoCreateEmptyDbContext : DbContext
    {
        public string DbConn { get; }

        public Action<DbContextOptionsBuilder, string> SetupAction { get; set; }

        internal AutoCreateEmptyDbContext(string dbConn, Action<DbContextOptionsBuilder, string> setupAction)
        {
            DbConn = dbConn;
            SetupAction = setupAction;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SetupAction(optionsBuilder, DbConn);
        }
    }
}
