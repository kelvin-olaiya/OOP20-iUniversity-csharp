using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public interface User
    {
        /**
         * Return a string with the name
         */
        string GetName();
        /**
         * Return a string with the last name
         */
        string GetLastName();
        /**
         * Return a string with the username
         */
        string GetUsername();
        /**
         * Return an int with the id
         */
        int GetId();
    }
    
    public enum Gender
    {
        /**
         * The user is male
         */
        MALE,
        /**
         * The user is female
         */
        FEMALE,
        /**
         * The user don't know
         */
        UNSPECIFIED
    }

    public enum UserType
    {
        /**
         * The user is a student
         */
        STUDENT,
        /**
         * The user is a teacher
         */
        TEACHER,
        /**
         * The user is an admin
         */
        ADMIN
    }
}