using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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



    // اسايمنت 2




namespace ConsoleAppEntity01
    {
        public class DatabaseOperations
        {
            private readonly ApplicationDbContext _context;

            public DatabaseOperations()
            {
                _context = new ApplicationDbContext();
            }

            // 1️ Student CRUD
            public void CreateStudent(Student student)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }

            public void ReadStudents()
            {
                var students = _context.Students.ToList();
                students.ForEach(s => Console.WriteLine($"{s.ID} - {s.FName} {s.LName} - {s.Address} - Age: {s.Age} - Dep: {s.Dep_Id}"));
            }

            public void UpdateStudent(int id, string newAddress)
            {
                var student = _context.Students.Find(id);
                if (student != null)
                {
                    student.Address = newAddress;
                    _context.SaveChanges();
                }
            }

            public void DeleteStudent(int id)
            {
                var student = _context.Students.Find(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
            }

            // 2️ Course CRUD
            public void CreateCourse(Course course)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            }

            public void ReadCourses()
            {
                var courses = _context.Courses.ToList();
                courses.ForEach(c => Console.WriteLine($"{c.ID} - {c.Name} - {c.Description} - Duration: {c.Duration} - TopicID: {c.Top_ID}"));
            }

            public void UpdateCourse(int id, string newDescription)
            {
                var course = _context.Courses.Find(id);
                if (course != null)
                {
                    course.Description = newDescription;
                    _context.SaveChanges();
                }
            }

            public void DeleteCourse(int id)
            {
                var course = _context.Courses.Find(id);
                if (course != null)
                {
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                }
            }

            // 3️ Topic CRUD
            public void CreateTopic(Topic topic)
            {
                _context.Topics.Add(topic);
                _context.SaveChanges();
            }

            public void ReadTopics()
            {
                var topics = _context.Topics.ToList();
                topics.ForEach(t => Console.WriteLine($"{t.ID} - {t.Name}"));
            }

            public void UpdateTopic(int id, string newName)
            {
                var topic = _context.Topics.Find(id);
                if (topic != null)
                {
                    topic.Name = newName;
                    _context.SaveChanges();
                }
            }

            public void DeleteTopic(int id)
            {
                var topic = _context.Topics.Find(id);
                if (topic != null)
                {
                    _context.Topics.Remove(topic);
                    _context.SaveChanges();
                }
            }

            // 4️ Stud_Course CRUD
            public void CreateStudCourse(Stud_Course studCourse)
            {
                _context.Stud_Courses.Add(studCourse);
                _context.SaveChanges();
            }

            public void ReadStudCourses()
            {
                var studCourses = _context.Stud_Courses.ToList();
                studCourses.ForEach(sc => Console.WriteLine($"{sc.stud_ID} - {sc.Course_ID} - Grade: {sc.Grade}"));
            }

            public void UpdateStudCourseGrade(int studentId, int courseId, string newGrade)
            {
                var studCourse = _context.Stud_Courses.Find(studentId);
                if (studCourse != null && studCourse.Course_ID == courseId)
                {
                    studCourse.Grade = newGrade;
                    _context.SaveChanges();
                }
            }

            public void DeleteStudCourse(int studentId, int courseId)
            {
                var studCourse = _context.Stud_Courses.FirstOrDefault(sc => sc.stud_ID == studentId && sc.Course_ID == courseId);
                if (studCourse != null)
                {
                    _context.Stud_Courses.Remove(studCourse);
                    _context.SaveChanges();
                }
            }

            // 5️ Department CRUD
            public void CreateDepartment(Department department)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }

            public void ReadDepartments()
            {
                var departments = _context.Departments.ToList();
                departments.ForEach(d => Console.WriteLine($"{d.ID} - {d.Name} - InstructorID: {d.Ins_ID} - HiringDate: {d.HiringDate}"));
            }

            public void UpdateDepartmentName(int id, string newName)
            {
                var department = _context.Departments.Find(id);
                if (department != null)
                {
                    department.Name = newName;
                    _context.SaveChanges();
                }
            }

            public void DeleteDepartment(int id)
            {
                var department = _context.Departments.Find(id);
                if (department != null)
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
                }
            }

            // 6️ Instructor CRUD
            public void CreateInstructor(Instructor instructor)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
            }

            public void ReadInstructors()
            {
                var instructors = _context.Instructors.ToList();
                instructors.ForEach(i => Console.WriteLine($"{i.ID} - {i.Name} - Salary: {i.Salary} - DeptID: {i.Dept_ID}"));
            }

            public void UpdateInstructorSalary(int id, decimal newSalary)
            {
                var instructor = _context.Instructors.Find(id);
                if (instructor != null)
                {
                    instructor.Salary = newSalary;
                    _context.SaveChanges();
                }
            }

            public void DeleteInstructor(int id)
            {
                var instructor = _context.Instructors.Find(id);
                if (instructor != null)
                {
                    _context.Instructors.Remove(instructor);
                    _context.SaveChanges();
                }
            }

            // 7️ Course_Inst CRUD
            public void CreateCourseInstructor(Course_Inst courseInst)
            {
                _context.Course_Instructors.Add(courseInst);
                _context.SaveChanges();
            }

            public void ReadCourseInstructors()
            {
                var courseInstructors = _context.Course_Instructors.ToList();
                courseInstructors.ForEach(ci => Console.WriteLine($"{ci.inst_ID} - {ci.Course_ID} - Evaluation: {ci.Evaluate}"));
            }

            public void UpdateCourseInstructorEvaluation(int instructorId, int courseId, string newEvaluation)
            {
                var courseInst = _context.Course_Instructors.FirstOrDefault(ci => ci.inst_ID == instructorId && ci.Course_ID == courseId);
                if (courseInst != null)
                {
                    courseInst.Evaluate = newEvaluation;
                    _context.SaveChanges();
                }
            }

            public void DeleteCourseInstructor(int instructorId, int courseId)
            {
                var courseInst = _context.Course_Instructors.FirstOrDefault(ci => ci.inst_ID == instructorId && ci.Course_ID == courseId);
                if (courseInst != null)
                {
                    _context.Course_Instructors.Remove(courseInst);
                    _context.SaveChanges();
                }
            }
        }
    }






}
