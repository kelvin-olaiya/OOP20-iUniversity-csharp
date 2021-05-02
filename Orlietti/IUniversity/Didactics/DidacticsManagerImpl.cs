using IUniversity;
using System;
using System.Collections.Generic;
using IUniversity.User;

namespace IUniversity.Didactics
{
    public class DidacticsManagerImpl : DidacticsManager
    {
        private ISet<DegreeProgramme> degreeProgrammes = new HashSet<DegreeProgramme>();
        private ISet<Course> courses = new HashSet<Course>();

        public ISet<DegreeProgramme> GetDegreeProgrammes()
        {
            return new HashSet<DegreeProgramme>(degreeProgrammes);
        }

        public ISet<Course> GetCourse()
        {
            return new HashSet<Course>(courses);
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public void AddDegreeProgramme(DegreeProgramme degreeProgramme)
        {
            this.degreeProgrammes.Add(degreeProgramme);
        }

        public void RemoveCourse(Course course)
        {
            this.courses.Remove(course);
        }

        public void RemoveDegreeProgramme(DegreeProgramme degreeProgramme)
        {
            this.degreeProgrammes.Remove(degreeProgramme);
        }
    }
}