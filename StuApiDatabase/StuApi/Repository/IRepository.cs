using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuApi.Models;
namespace StuApi.Repository
{
    public interface IRepository
    {
        List<Student> getStudents();

        void addStudent(Student student);

        Student getStudentById(string id);

        void deleteStudent(string id);

        void updateStudent(Student stu, string id);

        float[] getRange();
    }
}

