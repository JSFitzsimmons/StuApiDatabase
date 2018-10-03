using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuApi.Models
{
    public interface IStuContext
    {
        List<Student> getStudents();

        void addStudent(Student student);

        Student GetStudentById(int id);

        void deleteStudent(string id);

        void UpdateStudent(Student stu, int id);

        List<float> getRange();
    }
}