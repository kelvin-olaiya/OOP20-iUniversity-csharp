using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    public enum Gender { MALE, FEMALE, UNSPECIFIED }
    public enum UserType { STUDENT, TEACHER, ADMIN }
    public interface IStudent
    {
        string Name { get; }
        string LastName { get; }
        string Username { get; }
        int Id { get; }
        int RegistrationNumber { get; }

    }
}
