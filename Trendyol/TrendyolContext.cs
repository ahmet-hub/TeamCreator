using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Trendyol.Model;

namespace Trendyol
{
  public class TrendyolContext : DbContext
  {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      var path=Directory.GetCurrentDirectory();
      var fullPath = path + @"\TrendyolDb.db";  
      var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = fullPath };
      var connectionString = connectionStringBuilder.ToString();
      var connection = new SqliteConnection(connectionString);
      optionsBuilder.UseSqlite(connection);
      base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Employee> Employee { get; set; }
    public DbSet<Person> People { get; set; }
  }
}
