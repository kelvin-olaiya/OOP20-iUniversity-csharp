using System;
using System.Collections.Generic;
using IUniversity.Didactics;

namespace IUniversity.User
{
    public interface Student : User
    {
        /**
         * Return an int with the registration number
         */
        int GetRegistrationNumber();
        /**
         * Return the student's degree programme
         */
        DegreeProgramme GetDegreeProgramme();
    }
}