using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    class Student : IStudent
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
    }
}
