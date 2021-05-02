using System;
using System.Collections.Generic;
using IUniversity.User;

namespace IUniversity.Didactics
{
    public class DegreeProgrammeImpl : DegreeProgramme
    {
        private string name;
        private DegreeType type;
        private ISet<Course> courses;

        public DegreeProgrammeImpl(string name, DegreeType type, ISet<Course> courses)
        {
            this.name = name;
            this.type = type;
            this.courses = courses;
        }

        public string GetName()
        {
            return this.name;
        }

        public DegreeType GetType()
        {
            return this.type;
        }

        public ISet<Course> GetCourses()
        {
            return new HashSet<Course>(courses);
        }
    }
}