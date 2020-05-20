using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PostgresBoolConverter.Model;
using System;
using System.Linq;

namespace PostgresBoolConverter
{
    class Program
    {
        private const string server = "";
        private const string database = "";
        private const string username = "";
        private const string password = "";
        private static string _connectionString = $"Host={server};Database={database};Username={username};Password={password}";

        public static readonly ILoggerFactory LoggerFactory  = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddConsole(); });

        static void Main(string[] args)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseLoggerFactory(LoggerFactory).UseNpgsql(_connectionString);

            using(PostgresDbContext ctx = new PostgresDbContext(optionsBuilder.Options))
            {
                //the conversion from provider is woking good 
                var testQuery = ctx.TableEntity.FirstOrDefault(x => x.Item == "ACC");

                //this linq query works good
                var workingQuery = ctx.TableEntity.FirstOrDefault(x => x.HasCustomers == true);

                //this linq query don't work and throw a Npgsql.PostgresException 'argument of WHERE must be type boolean, not type character'
                var notWorkingQuery = ctx.TableEntity.FirstOrDefault(x => x.HasCustomers);
            }
            
            Console.ReadLine();
        }
    }
}
