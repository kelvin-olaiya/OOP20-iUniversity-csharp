using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public class ArchiveImpl : Archive
    {
        private ISet<Student> students = new HashSet<Student>();
        private ISet<Teacher> teachers = new HashSet<Teacher>();

        public ISet<Student> GetStudents()
        {
            return new HashSet<Student>(students);
        }

        public ISet<Teacher> GetTeachers()
        {
            return new HashSet<Teacher>(teachers);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public int GetNewStudentRegistrationNumber()
        {
            int registrationNumber = 0;
            foreach (Student student in this.students)
            {
                if (registrationNumber < student.GetRegistrationNumber())
                {
                    registrationNumber = student.GetRegistrationNumber();
                }
            }
            return ++registrationNumber;
        }

        public int GetNewTeacherRegistrationNumber()
        {
            int registrationNumber = 0;
            foreach (Teacher teacher in this.teachers)
            {
                if (registrationNumber < teacher.GetRegistrationNumber())
                {
                    registrationNumber = teacher.GetRegistrationNumber();
                }
            }
            return ++registrationNumber;
        }

        public int GetNewUserId()
        {
            int id = 0;
            ISet<User> users = new HashSet<User>();
            users.UnionWith(students);
            users.UnionWith(teachers);
            foreach (User user in users)
            {
                if (id < user.GetId())
                {
                    id = user.GetId();
                }
            }
            return ++id;
        }

    }    
}