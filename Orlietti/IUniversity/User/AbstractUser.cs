using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public abstract class AbstractUser : User
    {
        private string name;
        private string lastName;
        private string username;
        private DateTime dateOfBirth;
        private Gender gender;
        private string address;
        private int id;

        public AbstractUser()
        {}

        public AbstractUser(string name, string lastName, string username, DateTime dateOfBirth,
            Gender gender, string address, int id)
        {
            this.name = name;
            this.lastName = lastName;
            this.username = username;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.id = id;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public DateTime GetDateOfBirth()
        {
            return this.dateOfBirth;
        }

        public Gender GetGender() 
        {
            return this.gender;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public int GetId()
        {
            return this.id;
        }
        public override bool Equals(object obj)
        {
            return obj is AbstractUser user &&
                   name == user.name &&
                   lastName == user.lastName &&
                   username == user.username &&
                   dateOfBirth == user.dateOfBirth &&
                   gender == user.gender &&
                   address == user.address &&
                   id == user.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, lastName, username, dateOfBirth, gender, address, id);
        }
    }
}