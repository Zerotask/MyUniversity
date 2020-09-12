using Microsoft.AspNetCore.Mvc;
using MyUniversity.Data.Entities;
using MyUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUniversity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly CourseRepository _courseRepository;

        public CourseController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Course[]>> Get()
        {
            var courses = await _courseRepository.AllCourses();

            return Ok(courses);
        }
    }
}