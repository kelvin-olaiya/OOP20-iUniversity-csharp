using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    enum Gender { MALE, FEMALE, UNSPECIFIED }
    enum UserType { STUDENT, TEACHER, ADMIN }
    interface IStudent
    {
        string Name { get; }
        string LastName { get; }
        string Username { get; }
        int Id { get; }
        int RegistrationNumber { get; }

    }
}
