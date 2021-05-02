using System;
using System.Collections.Generic;
using System.Text;
using IUniversity.User;
using IUniversity.Didactics;
using NUnit.Framework;

namespace IUniversity.IUniversity.Test
{
    class DidacticsManagerTest
    {
        private DidacticsManager didacticsManager = new DidacticsManagerImpl();
        private SampleTestData sampleData = new SampleTestData();

        [Test]
        public void TestGetDegreeProgrammes() 
        {
            ISet<Course> courses = new HashSet<Course>();
            Course algebra = sampleData.GetAlgebra();
            Course analisiMat = sampleData.GetAnalisiMatematica();
            courses.Add(algebra);
            courses.Add(analisiMat);
            DegreeProgramme ingCivile = new DegreeProgrammeImpl("Ingegneria Civile", DegreeType.BACHELOR,courses);
            Assert.AreEqual("Ingegneria Civile", ingCivile.GetName());
            Assert.AreEqual(DegreeType.BACHELOR, ingCivile.GetType());
            Assert.AreEqual(courses, ingCivile.GetCourses());
        }
    
        [Test]
        public void TestGetCourseAndSetCourses() 
        {
            ISet<Course> courses = new HashSet<Course>();
            Course algebra = sampleData.GetAlgebra();
            Course analisiMat = sampleData.GetAnalisiMatematica();
            courses.Add(algebra);
            courses.Add(analisiMat);
            didacticsManager.AddCourse(algebra);
            didacticsManager.AddCourse(analisiMat);
            Assert.AreEqual(courses, didacticsManager.GetCourse());
        }
    }
}
