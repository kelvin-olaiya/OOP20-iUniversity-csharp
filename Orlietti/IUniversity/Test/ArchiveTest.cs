using System;
using System.Collections.Generic;
using System.Text;
using IUniversity.User;
using IUniversity.Didactics;
using NUnit.Framework;

namespace IUniversity.IUniversity.Test
{
    class ArchiveTest
    {
        private Archive archive = new ArchiveImpl();
        private SampleTestData sampleData = new SampleTestData();
    
        [Test]
        public void TestGetStudents() 
        {
            Student marioRossi = new StudentBuilder("Mario","Rossi",0,0)
                                                .Username("stu.mario.rossi")
                                                .DateOfBirth(new DateTime(1990, 8, 8))
                                                .Address("Via Don Minzoni")
                                                .Gender(Gender.MALE)
                                                .DegreeProgramme(sampleData.GetIngegneria())
                                                .Build();
            Assert.AreEqual("Mario", marioRossi.GetName());
            Assert.AreEqual("Rossi", marioRossi.GetLastName());
            Assert.AreEqual(0, marioRossi.GetId());
            Assert.AreEqual(0, marioRossi.GetRegistrationNumber());
            Assert.AreEqual("stu.mario.rossi", marioRossi.GetUsername());
            Assert.AreEqual(sampleData.GetIngegneria(), marioRossi.GetDegreeProgramme());
        }
    
        [Test]
        public void TestGetTeachers() 
        {
            ISet<Course> courses = new HashSet<Course>();
            Course algebra = sampleData.GetAlgebra();
            Course analisiMat = sampleData.GetAnalisiMatematica();
            courses.Add(algebra);
            courses.Add(analisiMat);
            Teacher claudioBravo = new TeacherBuilder("Claudio","Bravo",0,0)
                                                .Username("doc.claudio.bravo")
                                                .DateOfBirth(new DateTime(1990, 8, 8))
                                                .Address("Via Madonna della Rosa")
                                                .Gender(Gender.MALE)
                                                .Courses(courses)
                                                .Build();
            Assert.AreEqual("Claudio", claudioBravo.GetName());
            Assert.AreEqual("Bravo", claudioBravo.GetLastName());
            Assert.AreEqual(0, claudioBravo.GetId());
            Assert.AreEqual(0, claudioBravo.GetRegistrationNumber());
            Assert.AreEqual("doc.claudio.bravo", claudioBravo.GetUsername());
            Assert.AreEqual(courses, claudioBravo.GetCourses());
        }
    
        [Test]
        public void TestGetNewStudentRegistrationNumber() 
        {
            Student marioRossi = new StudentBuilder("Mario","Rossi",0,archive.GetNewStudentRegistrationNumber())
                                                .Username("stu.mario.rossi")
                                                .DateOfBirth(new DateTime(1990, 8, 8))
                                                .Address("Via Don Minzoni")
                                                .Gender(Gender.MALE)
                                                .DegreeProgramme(sampleData.GetIngegneria())
                                                .Build();
            archive.AddStudent(marioRossi);
            Student marioGrossi = new StudentBuilder("Mario","Grossi",1,archive.GetNewStudentRegistrationNumber())
                                                .Username("stu.mario.grossi")
                                                .DateOfBirth(new DateTime(1990, 8, 8))
                                                .Address("Via Madonna della Rosa")
                                                .Gender(Gender.MALE)
                                                .DegreeProgramme(sampleData.GetIngegneria())
                                                .Build();
            archive.AddStudent(marioGrossi);
            Assert.AreEqual(1,marioRossi.GetRegistrationNumber());
            Assert.AreEqual(2,marioGrossi.GetRegistrationNumber());
        }
    
        [Test]
        public void TestGetNewTeacherRegistrationNumber() 
        {
            ISet<Course> courses = new HashSet<Course>();
            Course algebra = sampleData.GetAlgebra();
            Course analisiMat = sampleData.GetAnalisiMatematica();
            courses.Add(algebra);
            courses.Add(analisiMat);
            Teacher claudioBravo = new TeacherBuilder("Claudio","Bravo",0,archive.GetNewTeacherRegistrationNumber())
                                                .Username("doc.claudio.bravo")
                                                .DateOfBirth(new DateTime(1990, 8, 8))
                                                .Address("Via Madonna della Rosa")
                                                .Gender(Gender.MALE)
                                                .Courses(courses)
                                                .Build();
            archive.AddTeacher(claudioBravo);
            Teacher francescoFrancoletti = new TeacherBuilder("Francesco","Francoletti",0,archive.GetNewTeacherRegistrationNumber())
                                                        .Username("doc.claudio.bravo")
                                                        .DateOfBirth(new DateTime(1990, 8, 8))
                                                        .Address("Via Madonna della Rosa")
                                                        .Gender(Gender.MALE)
                                                        .Courses(courses)
                                                        .Build();
            archive.AddTeacher(francescoFrancoletti);
            Assert.AreEqual(1,claudioBravo.GetRegistrationNumber());
            Assert.AreEqual(2,francescoFrancoletti.GetRegistrationNumber());
        }
    }
}
