using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    interface IStudentRegistrationStrategy
    {
        void register(IList<IStudent> list, IStudent student);
    }
}
