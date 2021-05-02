using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace IUniversity.Exams
{
    ///<inheritdoc/>
    class AlphabeticalOrderStrategy : IStudentRegistrationStrategy
    {
        public void Register(ref IList<IStudent> list, IStudent student)
        {
            list.Add(student);
            list = list.OrderBy(s => s.LastName.ToLower()).ToList();
        }
    }

    ///<inheritdoc/>
    class AtTheTopOfListStrategy : IStudentRegistrationStrategy
    {
        public void Register(ref IList<IStudent> list, IStudent student)
        {
            list.Insert(0, student);
        }
    }

    ///<inheritdoc/>
    class AtTheEndOfListStrategy : IStudentRegistrationStrategy
    {
        public void Register(ref IList<IStudent> list, IStudent student)
        {
            list.Add(student);
        }
    }

    /// <summary>
    /// Factory for student registration strategy
    /// </summary>
    public class StudentRegistrationStrategyFactory
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
