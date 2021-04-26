using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    interface IStudentRegistrationStrategy
    {
        void register(ref IList<IStudent> list, IStudent student);
    }
}
