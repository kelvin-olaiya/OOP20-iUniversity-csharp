using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public interface IStudentRegistrationStrategy
    {
        /// <summary>
        /// Registration strategy
        /// </summary>
        /// <param name="list">The list to witch add the student</param>
        /// <param name="student">The student to add</param>
        void Register(ref IList<IStudent> list, IStudent student);
    }
}
