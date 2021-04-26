using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace IUniversity.Exams
{
    class AlphabeticalOrderStrategy : IStudentRegistrationStrategy
    {
        public void register(ref IList<IStudent> list, IStudent student)
        {
            list.Add(student);
            list = list.OrderBy(s => s.LastName.ToLower()).ToList();
        }
    }

    class AtTheTopOfListStrategy : IStudentRegistrationStrategy
    {
        public void register(ref IList<IStudent> list, IStudent student)
        {
            list.Insert(0, student);
        }
    }

    class AtTheEndOfListStrategy : IStudentRegistrationStrategy
    {
        public void register(ref IList<IStudent> list, IStudent student)
        {
            list.Add(student);
        }
    }

    class StudentRegistrationStrategyFactory
    {
        public IStudentRegistrationStrategy AlphabeticalOrder()
        {
            return new AlphabeticalOrderStrategy();
        }

        public IStudentRegistrationStrategy AtTheEndOfList()
        {
            return new AtTheEndOfListStrategy();
        }

        public IStudentRegistrationStrategy AtTheTopOfList()
        {
            return new AtTheTopOfListStrategy();
        }
    }
}
