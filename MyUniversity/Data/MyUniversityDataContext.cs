using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MyUniversity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUniversity.Data
{
    public class MyUniversityDataContext
    {
        public IMongoCollection<Course> Courses => _database.GetCollection<Course>("courses");

        private readonly IMongoDatabase _database;
        private const string DATABASE_NAME = "MyUniversity";

        public MyUniversityDataContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["Databases:MongoDB:ConnectionString"]);
            _database = client.GetDatabase(DATABASE_NAME);

            if (!client.ListDatabaseNames().ToList().Contains(DATABASE_NAME))
            {
                Task.Run(async () => await SeedData());
            }
        }

        private async Task SeedData()
        {
            var course = new Course
            {
                Name = "Math",
                Description = "This is a math course.",
                LastUpdate = DateTime.Now
            };

            await Courses.InsertOneAsync(course);
        }
    }
}