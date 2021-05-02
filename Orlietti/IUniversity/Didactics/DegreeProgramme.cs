using System;
using System.Collections.Generic;
using IUniversity.User;

namespace IUniversity.Didactics
{ 
    public interface DegreeProgramme
    {
        /**
         * Return a string with the name of degree programme
         */
        string GetName();

        /**
         * Return the degree type
         */
        DegreeType GetType();

        ISet<Course> GetCourses();
    }
    
    public enum DegreeType
    {
        /**
         * The duration is three years
         */
        BACHELOR,
        /**
         * The duration is five years
         */
        MASTER
    }
}

