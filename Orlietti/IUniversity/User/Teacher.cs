using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public interface Teacher : User
    {
        /**
         * Return an int with the registration number
         */
        int GetRegistrationNumber();
        /**
         * Return the teacher's set of courses
         */
        ISet<Course> GetCourses();
    }
}

