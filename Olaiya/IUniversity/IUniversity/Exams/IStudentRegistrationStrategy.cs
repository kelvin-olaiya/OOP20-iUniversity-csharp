using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public interface IStudentRegistrationStrategy
    {
        void Register(ref IList<IStudent> list, IStudent student);
    }
}
