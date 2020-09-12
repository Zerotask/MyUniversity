using GraphQL.Types;
using MyUniversity.Data.Entities;

namespace MyUniversity.GraphQL.Types
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.LastUpdate);
            Field(x => x.CountStudents);
        }
    }
}