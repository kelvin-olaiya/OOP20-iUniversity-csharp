using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace IUniversity.Exams
{
    class AlphabeticalOrderStrategy : IStudentRegistrationStrategy
    {
        public void register(IList<IStudent> list, IStudent student)
        {
            list.Add(student);
            list = list.OrderBy(s => s.LastName).ToList();
        }
    }

    class AtTheTopOfListStrategy : IStudentRegistrationStrategy
    {
        public void register(IList<IStudent> list, IStudent student)
        {
            list.Insert(0, student);
        }
    }

    class AtTheEndOfListStrategy : IStudentRegistrationStrategy
    {
        public void register(IList<IStudent> list, IStudent student)
        {
            list.Add(student);
        }
    }

    class StudentRegistrationFactory
    {
        public IStudentRegistrationStrategy AlphabeticalOrder()
        {
            return new AlphabeticalOrderStrategy();
        }

        public IStudentRegistrationStrategy AtTheEndOfList()
        {
            return new AtTheEndOfListStrategy();
        }

        public IStudentRegistrationStrategy AtTheTopOFList()
        {
            return new AtTheTopOfListStrategy();
        }
    }
}
