using GraphQL.Types;
using MyUniversity.GraphQL.Types;
using MyUniversity.Repositories;

namespace MyUniversity.GraphQL
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(CourseRepository courseRepository)
        {
            Field<ListGraphType<CourseType>>(
                "courses",
                resolve: context => courseRepository.AllCourses()
            );
        }
    }
}