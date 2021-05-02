using System;
using System.Collections.Generic;
using System.Text;
using IUniversity.User;
using IUniversity.Didactics;
using NUnit.Framework;

namespace IUniversity.IUniversity.Test
{
    class SampleTestData
    {
        private Course analisiMatematica = new CourseImpl("Analisi Matematica", 12);
        private Course programmazione = new CourseImpl("Programmazione", 12);
        private Course algebra = new CourseImpl("Algebra e Geometria", 6);
        private ISet<Course> courses = new HashSet<Course>();
        private DegreeProgramme ingegneria;
        private Student marioRossi;
        private Student lucianoVerdi;
        private Student lucaBianchi;


        public SampleTestData()
        {
            
            courses.Add(analisiMatematica);
            courses.Add(programmazione);
            courses.Add(algebra);
            ingegneria = new DegreeProgrammeImpl("Ingegneria e scienze informatiche", DegreeType.BACHELOR, courses);
            marioRossi = new StudentBuilder("Mario", "Rossi", 1, 1)
                                                    .Address("via")
                                                    .DateOfBirth(DateTime.Now)
                                                    .DegreeProgramme(ingegneria)
                                                    .Gender(Gender.MALE)
                                                    .Username("stu.rossi.mario")
                                                    .Build();
            lucianoVerdi = new StudentBuilder("Luciano", "Verdi", 2, 2)
                                                    .Address("via")
                                                    .DateOfBirth(DateTime.Now)
                                                    .DegreeProgramme(ingegneria)
                                                    .Gender(Gender.MALE)
                                                    .Username("stu.verdi.luciani")
                                                    .Build();
             lucaBianchi = new StudentBuilder("Luca", "Bianchi", 3, 3)
                                                    .Address("via")
                                                    .DateOfBirth(DateTime.Now)
                                                    .DegreeProgramme(ingegneria)
                                                    .Gender(Gender.MALE)
                                                    .Username("stu.bianchi.luca")
                                                    .Build();
    }
        
        public Course GetAnalisiMatematica()
        {
            return analisiMatematica;
        }

        public Course GetProgrammazione()
        {
            return programmazione;
        }

        public Course GetAlgebra()
        {
            return algebra;
        }

        public DegreeProgramme GetIngegneria()
        {
            return ingegneria;
        }

        public Student GetLucianoVerdi()
        {
            return lucianoVerdi;
        }

        public Student GetMarioRossi()
        {
            return marioRossi;
        }

        public Student GetLucaBianchi()
        {
            return lucaBianchi;
        }
    }
}