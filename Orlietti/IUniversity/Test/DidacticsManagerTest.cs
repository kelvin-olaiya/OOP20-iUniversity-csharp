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
            Assert.Equals("Ingegneria Civile", ingCivile.GetName());
            Assert.Equals(DegreeType.BACHELOR, ingCivile.GetType());
            Assert.Equals(courses, ingCivile.GetCourses());
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
            Assert.Equals(courses, didacticsManager.GetCourse());
        }
    
        [Test]
        public void TestSetDegreeProgrammes() 
        {
            ISet<Course> courses = new HashSet<Course>();
            Course algebra = sampleData.GetAlgebra();
            Course analisiMat = sampleData.GetAnalisiMatematica();
            courses.Add(algebra);
            courses.Add(analisiMat);
            DegreeProgramme ingCivile = new DegreeProgrammeImpl("Ingegneria Civile", DegreeType.BACHELOR,courses);
            DegreeProgramme ingInformatica = new DegreeProgrammeImpl("Ingegneria Informatica", DegreeType.MASTER,courses);
            ISet<DegreeProgramme> degreeProgrammes = new HashSet<DegreeProgramme>();
            didacticsManager.AddDegreeProgramme(ingCivile);
            didacticsManager.AddDegreeProgramme(ingInformatica);
            Assert.Equals(degreeProgrammes,didacticsManager.GetDegreeProgrammes());
        }
    }
}
