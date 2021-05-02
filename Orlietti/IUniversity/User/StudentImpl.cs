using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public class StudentImpl : AbstractUser, Student
    {
        private int registrationNumber;
        private DegreeProgramme degreeProgramme;

        public StudentImpl(string name, string lastName, string username, DateTime dateOfBirth, Gender gender,
            string address, int id, int registrationNumber, DegreeProgramme degreeProgramme) : base(name, lastName, username, dateOfBirth, gender, address, id)
        {
            this.registrationNumber = registrationNumber;
            this.degreeProgramme = degreeProgramme;
        }

        public int GetRegistrationNumber()
        {
            return this.registrationNumber;
        }

        public DegreeProgramme GetDegreeProgramme()
        {
            return this.degreeProgramme;
        }
        public override bool Equals(object obj)
        {
            return obj is StudentImpl impl &&
                   base.Equals(obj) &&
                   registrationNumber == impl.registrationNumber &&
                   EqualityComparer<DegreeProgramme>.Default.Equals(degreeProgramme, impl.degreeProgramme);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), registrationNumber, degreeProgramme);
        }
    }

    public class StudentBuilder
    {
        private string name;
        private string lastName;
        private string username;
        private DateTime dateOfBirth;
        private Gender gender;
        private string address;
        private int id;
        private int registrationNumber;
        private DegreeProgramme degreeProgramme;

        public StudentBuilder(string name, string lastName, int id, int registrationNumber)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = id;
            this.registrationNumber = registrationNumber;
        }

        public StudentBuilder Username(string username)
        {
            this.username = username;
            return this;
        }

        public StudentBuilder DateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
            return this;
        }

        public StudentBuilder Gender(Gender gender)
        {
            this.gender = gender;
            return this;
        }

        public StudentBuilder Address(string address)
        {
            this.address = address;
            return this;
        }

        public StudentBuilder DegreeProgramme(DegreeProgramme degreeProgramme)
        {
            this.degreeProgramme = degreeProgramme;
            return this;
        }

        public StudentImpl Build()
        {
            return new StudentImpl(this.name,this.lastName, this.username, this.dateOfBirth, this.gender, this.address, 
                this.id, this.registrationNumber, this.degreeProgramme);
        }

    }
}