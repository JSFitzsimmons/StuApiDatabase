using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using StuApi.Models;

namespace StuApi.Repository
{
    public class StuRepository : IRepository
    {
        string connectStr = "Server=localhost; Database=StudentDB; UID=bill; Password=1777";

        public List<Student> getStudents()
        {
            string sql = "Select * from Student";
            using (var connection = new MySqlConnection(connectStr))
            {
                List<Student> stu = connection.Query<Student>(sql).ToList();
                return stu;
            }
        }

        public Student getStudentById(string id)
        {

            string code = "Select * from Student where StudentId=@StudentId";
            using (var connection = new MySqlConnection(connectStr))
            {
                Student stu = connection.QuerySingleOrDefault<Student>(code, new { StudentId = id});
                return stu;
            }
        }

        public float[] getRange()
        {

            string code = "Select min(studentGpa) as min, max(StudentGpa) as max from Student";
            float[] range = new float[2];
            using (var connection = new MySqlConnection(connectStr))
            {
                var result = connection.Query(code).Single();
                range[0] = result.min();
                range[1] = result.max();
                return range;
            }
        }


        public void addStudent(Student stu)
        {
            string code = "insert into Student (StudentId, StudentName, StudentGpa) " +
                "Values (@StudentId, @StudentName, @StudentGpa);";
            using (var connection = new MySqlConnection(connectStr))
            {
                connection.Execute(code, new {StudentName = stu.StudentName, StudentId = stu.StudentId, StudentGpa = stu.StudentGpa});
            }
        }

        public void updateStudent(Student stu, string id)
        {
            string code = "UPDATE Student SET StudentId = @StudentId, StudentName = @StudentName, " +
                "StudentGpa = @StudentGPA WHERE StudentId = @StudentId;";
            using (var connection = new MySqlConnection(connectStr))
            {
                connection.Execute(code, new { StudentName = stu.StudentName, StudentId = stu.StudentId, StudentGpa = stu.StudentGpa });
            }
        }


        public void deleteStudent(string id)
        {
            string code = "delete from Student where StudentId = @StudentId;";
            using (var connection = new MySqlConnection(connectStr))
            {
                connection.Execute(code, new {StudentId = id});
            }
        }
    }
}
