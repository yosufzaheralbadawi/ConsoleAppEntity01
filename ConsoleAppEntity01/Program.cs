using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ConsoleAppEntity01.ConsoleAppEntity01;

namespace ConsoleAppEntity01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbOps = new DatabaseOperations();

            var student = new Student { FName = "Ali", LName = "Mohamed", Address = "Cairo", Age = 23, Dep_Id = 1 };
            dbOps.CreateStudent(student);
            dbOps.UpdateStudent(student.ID, "Giza");
            dbOps.DeleteStudent(student.ID);
            dbOps.ReadStudents();

            var course = new Course { Name = "Math", Description = "Basic Math", Duration = "45", Top_ID = 1 };
            dbOps.CreateCourse(course);
            dbOps.UpdateCourse(course.ID, "Advanced Math");
            dbOps.DeleteCourse(course.ID);
            dbOps.ReadCourses();

            var topic = new Topic { Name = "Mathematics" };
            dbOps.CreateTopic(topic);
            dbOps.UpdateTopic(topic.ID, "Advanced Mathematics");
            dbOps.DeleteTopic(topic.ID);
            dbOps.ReadTopics();

            var studCourse = new Stud_Course { stud_ID = student.ID, Course_ID = course.ID, Grade = "B" };
            dbOps.CreateStudCourse(studCourse);
            dbOps.UpdateStudCourseGrade(studCourse.stud_ID, studCourse.Course_ID, "A");
            dbOps.DeleteStudCourse(studCourse.stud_ID, studCourse.Course_ID);
            dbOps.ReadStudCourses();

            var department = new Department { Name = "Computer Science", Ins_ID = 1, HiringDate = DateTime.Now };
            dbOps.CreateDepartment(department);
            dbOps.UpdateDepartmentName(department.ID, "Software Engineering");
            dbOps.DeleteDepartment(department.ID);
            dbOps.ReadDepartments();

            var instructor = new Instructor { Name = "Dr. Ahmed", Salary = 10000, Dept_ID = department.ID };
            dbOps.CreateInstructor(instructor);
            dbOps.UpdateInstructorSalary(instructor.ID, 12000);
            dbOps.DeleteInstructor(instructor.ID);
            dbOps.ReadInstructors();

            var courseInstructor = new Course_Inst { inst_ID = instructor.ID, Course_ID = course.ID, Evaluate = "Excellent" };
            dbOps.CreateCourseInstructor(courseInstructor);
            dbOps.UpdateCourseInstructorEvaluation(courseInstructor.inst_ID, courseInstructor.Course_ID, "Very Good");
            dbOps.DeleteCourseInstructor(courseInstructor.inst_ID, courseInstructor.Course_ID);
            dbOps.ReadCourseInstructors();

        }
    }

    
}
