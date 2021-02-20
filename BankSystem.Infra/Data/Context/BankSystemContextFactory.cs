using System;
using System.IO;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BankSystem.Infra.Data.Context
{
  public class BankSystemContextFactory : IDesignTimeDbContextFactory<BankSystemContext>
  {
    private readonly IConfiguration _configuration;
    
    public BankSystemContextFactory() 
    {
        _configuration = new ConfigurationBuilder()
			.SetBasePath(String.Format(@"{0}../../BankSystem.Api/", Directory.GetCurrentDirectory()))
			.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
			.Build();
    }

    public BankSystemContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BankSystemContext>();
        var connectionString = _configuration.GetConnectionString("BankSystemDatabase");

        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new BankSystemContext(builder.Options);
    }
  }
}