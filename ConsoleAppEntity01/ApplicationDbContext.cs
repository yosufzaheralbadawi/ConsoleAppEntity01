using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEntity01
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext():base()
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Stud_Course> Stud_Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course_Inst> Course_Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\Local;Database=TestDB;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Dep_Id { get; set; }
    }

    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Top_ID { get; set; }
    }

    public class Topic
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Stud_Course
    {
        [Key]
        public int stud_ID { get; set; }
        public int Course_ID { get; set; }
        public string Grade { get; set; }
    }

    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Ins_ID { get; set; }
        public DateTime HiringDate { get; set; }
    }

    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Bouns { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public decimal HourRate { get; set; }
        public int Dept_ID { get; set; }
    }

    public class Course_Inst
    {
        [Key]
        public int inst_ID { get; set; }
        public int Course_ID { get; set; }
        public string Evaluate { get; set; }
    }
}
