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
            Assert.Equals("Mario", marioRossi.GetName());
            Assert.Equals("Rossi", marioRossi.GetLastName());
            Assert.Equals(0, marioRossi.GetId());
            Assert.Equals(0, marioRossi.GetRegistrationNumber());
            Assert.Equals("stu.mario.rossi", marioRossi.GetUsername());
            Assert.Equals(sampleData.GetIngegneria(), marioRossi.GetDegreeProgramme());
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
            Assert.Equals("Claudio", claudioBravo.GetName());
            Assert.Equals("Bravo", claudioBravo.GetLastName());
            Assert.Equals(0, claudioBravo.GetId());
            Assert.Equals(0, claudioBravo.GetRegistrationNumber());
            Assert.Equals("doc.claudio.bravo", claudioBravo.GetUsername());
            Assert.Equals(courses, claudioBravo.GetCourses());
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
            Assert.Equals(1,marioRossi.GetRegistrationNumber());
            Assert.Equals(2,marioGrossi.GetRegistrationNumber());
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
            Assert.Equals(1,claudioBravo.GetRegistrationNumber());
            Assert.Equals(2,francescoFrancoletti.GetRegistrationNumber());
        }
    }
}
