using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MyUniversity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUniversity.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;
        private const string DatabaseName = "MyUniversity";

        public IMongoCollection<Course> Courses => _database.GetCollection<Course>("courses");

        /// <summary>
        /// Create an MongoDB database instance and execute the seeding if the database doesn't exist.
        /// </summary>
        /// <param name="configuration">The configuration object via DI</param>
        public DbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["Databases:MongoDB:ConnectionString"]);
            _database = client.GetDatabase(DatabaseName);

            if (!client.ListDatabaseNames().ToList().Contains(DatabaseName))
            {
                Task.Run(async () => await SeedData());
            }
        }

        /// <summary>
        /// Seed some example data.
        /// </summary>
        /// <returns>Returns an awaitable async operation</returns>
        private async Task SeedData()
        {
            var courses = new List<Course>();
            courses.Add(new Course
            {
                Name = "Math",
                Description = "This is a math course.",
                LastUpdate = DateTime.Now
            });
            courses.Add(new Course
            {
                Name = "History",
                Description = "This is a history course.",
                LastUpdate = DateTime.Now
            });
            courses.Add(new Course
            {
                Name = "Computer Science",
                Description = "This is a computer science course.",
                LastUpdate = DateTime.Now
            });
            courses.Add(new Course
            {
                Name = "Art",
                Description = "This is an art course.",
                LastUpdate = DateTime.Now
            });
            courses.Add(new Course
            {
                Name = "Economics",
                Description = "This is an economics course.",
                LastUpdate = DateTime.Now
            });

            await Courses.InsertManyAsync(courses);
        }
    }
}