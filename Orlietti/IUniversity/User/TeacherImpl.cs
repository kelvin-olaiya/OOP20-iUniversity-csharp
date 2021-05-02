using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public class TeacherImpl : AbstractUser, Teacher
    {
        private int registrationNumber;
        private ISet<Course> courses;

        public TeacherImpl(string name, string lastName, string username, DateTime dateOfBirth, Gender gender,
            string address, int id, int registrationNumber, ISet<Course> courses) : base(name, lastName, username, dateOfBirth, gender, address, id)
        {
            this.registrationNumber = registrationNumber;
            this.courses = courses;
        }

        public int GetRegistrationNumber()
        {
            return this.registrationNumber;
        }

        public ISet<Course> GetCourses()
        {
            return new HashSet<Course>(courses);
        }
        public override bool Equals(object obj)
        {
            return obj is TeacherImpl impl &&
                   base.Equals(obj) &&
                   registrationNumber == impl.registrationNumber &&
                   EqualityComparer<ISet<Course>>.Default.Equals(courses, impl.courses);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), registrationNumber, courses);
        }
    }

    public class TeacherBuilder
    {
        private string name;
        private string lastName;
        private string username;
        private DateTime dateOfBirth;
        private Gender gender;
        private string address;
        private int id;
        private int registrationNumber;
        private ISet<Course> courses;

        public TeacherBuilder(string name, string lastName, int id, int registrationNumber)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = id;
            this.registrationNumber = registrationNumber;
        }

        public TeacherBuilder Username(string username)
        {
            this.username = username;
            return this;
        }

        public TeacherBuilder DateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
            return this;
        }

        public TeacherBuilder Gender(Gender gender)
        {
            this.gender = gender;
            return this;
        }

        public TeacherBuilder Address(string address)
        {
            this.address = address;
            return this;
        }

        public TeacherBuilder Courses(ISet<Course> courses)
        {
            this.courses = courses;
            return this;
        }

        public TeacherImpl Build()
        {
            return new TeacherImpl(this.name, this.lastName, this.username, this.dateOfBirth, this.gender, this.address,
                this.id, this.registrationNumber, this.courses);
        }
    }
}