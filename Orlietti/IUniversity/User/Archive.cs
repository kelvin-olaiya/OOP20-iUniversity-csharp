using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public interface Archive
    {
        /**
         * Return the set of students
         */
        ISet<Student> GetStudents();
        /**
         * Return the set of teachers
         */
        ISet<Teacher> GetTeachers();
        /**
         * Add the student
         */
        void AddStudent(Student student);
        /**
         * Add the teacher
         */
        void AddTeacher(Teacher teacher);
        /**
         * Return an int with the new student registration number
         */
        int GetNewStudentRegistrationNumber();
        /**
         * Return an int with the new teacher registration number
         */
        int GetNewTeacherRegistrationNumber();
        /**
         * Return an int with the new user id
         */
        int GetNewUserId();
    }
}


