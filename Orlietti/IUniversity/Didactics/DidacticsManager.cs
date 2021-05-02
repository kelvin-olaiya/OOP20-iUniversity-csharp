using System;
using System.Collections.Generic;
using IUniversity.User;

namespace IUniversity.Didactics
{
    public interface DidacticsManager
    {
        /**
         * Return the set of degree programme
         */
        ISet<DegreeProgramme> GetDegreeProgrammes();
        /**
         * Return the set of courses
         */
        ISet<Course> GetCourse();
        /**
         * Add the course
         */
        void AddCourse(Course course);
        /**
         * Add the degree programme 
         */
        void AddDegreeProgramme(DegreeProgramme degreeProgramme);
        /**
         * Remove the degree programme
         */
        void RemoveCourse(Course course);
        /**
         * Remove the degree programme
         */
        void RemoveDegreeProgramme(DegreeProgramme degreeProgramme);
    }
}