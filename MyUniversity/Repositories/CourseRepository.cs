using MongoDB.Bson;
using MongoDB.Driver;
using MyUniversity.Data;
using MyUniversity.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyUniversity.Repositories
{
    public class CourseRepository
    {
        private MyUniversityDataContext _dataContext;

        public CourseRepository(MyUniversityDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Course>> AllCourses()
        {
            return await _dataContext.Courses
                .Find(new BsonDocument())
                .ToListAsync();
        }
    }
}