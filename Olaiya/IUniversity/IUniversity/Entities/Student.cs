using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    public class Student : IStudent
    {
        public string Name { get; }

        public string LastName { get; }

        public string Username { get; }

        public int Id { get; }

        public int RegistrationNumber { get; }

        public Student(string name, string lastName, string username, int id, int registrationNumber)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Username = username;
            this.Id = id;
            this.RegistrationNumber = registrationNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Name == student.Name &&
                   LastName == student.LastName &&
                   Username == student.Username &&
                   Id == student.Id &&
                   RegistrationNumber == student.RegistrationNumber;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, LastName, Username, Id, RegistrationNumber);
        }
    }
}
