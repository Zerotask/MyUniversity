using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyUniversity.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [Description("Number of students attending this course.")]
        public int CountStudents { get; set; }
    }
}