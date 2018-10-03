using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StuApi.Models
{
    public class StuContext : IStuContext
    {
        string connectStr = "Server=localhost; Database=StudentDB; UID=bill; Password=1777";
        List<Student> database;

        public StuContext()
        {
            database = new List<Student>();
            //this.loadFile();
        }

        public List<Student> getStudents()
        {
            string sql = "Select * from Student";
            using (var connection = new MySqlConnection(connectStr))
            {
                List<Student> stu = connection.Query<Student>(sql).ToList();
                return stu;
            }
        }

        public Student GetStudentById(int id)
        {
            /*
            string code = "Select * from Student where StudentId=@id";
            using (var connection = new MySqlConnection(connectStr))
            {
                Student stu = <Student> connection.Query<Student>(code);
                return stu;
            }*/
            return null;
        }

        List<float> getRange()
        {
            /*
            string code = "Select min(studentId), max(StudentId) from Student";
            using (var connection = new MySqlConnection(connectStr))
            {
                List<float> vals = <List<float>> connection.Query<Student>(code);
                return vals;
            }*/
            return null;
        }


        public void addStudent(Student student)
        {
            string code = "insert into Student (StudentId, StudentName, StudentGpa) Values (@StudentId, @StudentName, @StudentGpa);";
            using (var connection = new MySqlConnection(connectStr))
            {
                connection.Execute(code, student);
            }
        }

        public void UpdateStudent(Student student, int id)
        {
            //remove previous version 
            //deleteStudent(stu);
            //database.Add(stu);
            string code = "UPDATE Student SET StudentId = @student.studentId, StudentName = @student.studentName, " +
                "StudentGpa = @student.studentGPA WHERE StudentId = @id;";
            using (var connection = new MySqlConnection(connectStr))
            {
                connection.Execute(code, student);
            }
        }


        public void deleteStudent(string id)
        {
            //database.Remove(GetStudentById(int.Parse(stu.StudentId)));
            string code = "delete from Student where studentId = @id;";
            using (var connection = new MySqlConnection(connectStr))
            {
                connection.Execute(code, id);
            }
        }

        List<float> IStuContext.getRange()
        {
            throw new NotImplementedException();
        }
    }
}

