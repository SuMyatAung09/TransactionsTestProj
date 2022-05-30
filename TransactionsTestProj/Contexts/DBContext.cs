using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TransactionsTestProj.Entities;
using Microsoft.EntityFrameworkCore;

namespace TransactionsTestProj
{
    public partial class DBContext : DbContext
    {
        #region Contstructors
        protected string ConnectionString { get; }
        public DBContext()
        {
        }
        public DBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<Transactions> Transactions { get; set; }
        
        #endregion

        #region EntityFrameworkCore
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = readConnectionString();
                optionsBuilder.UseSqlServer(connStr, builder => builder.EnableRetryOnFailure());
            }
#if DEBUG
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
#endif
        }

        string readConnectionString()
        {

            if (!string.IsNullOrEmpty(ConnectionString))
            {
                return ConnectionString;
            }
            var connectionString = Environment.GetEnvironmentVariable($"CONN_TransactionTestDB");

            return connectionString;
        }

        //async Task<string> readSecretAsync(string keyVaultUri, string secretName)
        //{
        //    var result = string.Empty;

        //    try
        //    {
        //        var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
        //        var response = await client.GetSecretAsync(secretName);

        //        result = response.Value.Value;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    return result;
        //}

    
        #endregion
    }
}
