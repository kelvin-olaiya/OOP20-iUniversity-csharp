using IUniversity.Entities;
using IUniversity.Exams;
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using System.Linq;

namespace IUniversity.Test
{
    class StudentRegistrationStrategyFactoryTest
    {
        private readonly StudentRegistrationStrategyFactory strategyFactory = new StudentRegistrationStrategyFactory();
        private readonly SampleData sd = new SampleData();
        private readonly IStudent marioRossi;
        private readonly IStudent lucianoVerdi;
        private readonly IStudent lucaBianchi;

        private IList<IStudent> registrationList;

        public StudentRegistrationStrategyFactoryTest()
        {
            marioRossi = sd.MarioRossi;
            lucianoVerdi = sd.LucianoVerdi;
            lucaBianchi = sd.LucaBianchi;
        }
        [SetUp]
        public void Init()
        {
            registrationList = new List<IStudent>();
        }

        [Test]
        public void TestAtTheTopOfList()
        {
            IList<IStudent> list = new List<IStudent>();
            IStudentRegistrationStrategy registrationStrategy = strategyFactory.AtTheTopOfList();
            registrationStrategy.Register(ref registrationList, marioRossi);
            registrationStrategy.Register(ref registrationList, lucaBianchi);
            registrationStrategy.Register(ref registrationList, lucianoVerdi);
            list.Add(lucianoVerdi);
            list.Add(lucaBianchi);
            list.Add(marioRossi);
            Assert.True(registrationList.SequenceEqual(list));
            registrationList.Clear();
            list.Clear();
            registrationStrategy.Register(ref registrationList, lucaBianchi);
            registrationStrategy.Register(ref registrationList, marioRossi);
            registrationStrategy.Register(ref registrationList, lucianoVerdi);
            list.Add(lucianoVerdi);
            list.Add(marioRossi);
            list.Add(lucaBianchi);
            Assert.True(registrationList.SequenceEqual(list));
        }

        [Test]
        public void TestAtTheEndOfList()
        {
            IList<IStudent> list = new List<IStudent>();
            IStudentRegistrationStrategy registrationStrategy = strategyFactory.AtTheEndOfList();
            registrationStrategy.Register(ref registrationList, marioRossi);
            registrationStrategy.Register(ref registrationList, lucaBianchi);
            registrationStrategy.Register(ref registrationList, lucianoVerdi);
            list.Add(marioRossi);
            list.Add(lucaBianchi);
            list.Add(lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
            registrationList.Clear();
            list.Clear();
            registrationStrategy.Register(ref registrationList, lucaBianchi);
            registrationStrategy.Register(ref registrationList, marioRossi);
            registrationStrategy.Register(ref registrationList, lucianoVerdi);
            list.Add(lucaBianchi);
            list.Add(marioRossi);
            list.Add(lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
        }

        [Test]
        public void TestAlphabeticalOrder()
        {
            IList<IStudent> list = new List<IStudent>();
            IStudentRegistrationStrategy registrationStrategy = strategyFactory.AlphabeticalOrder();
            registrationStrategy.Register(ref registrationList, marioRossi);
            registrationStrategy.Register(ref registrationList, lucaBianchi);
            registrationStrategy.Register(ref registrationList, lucianoVerdi);
            list.Add(lucaBianchi);
            list.Add(marioRossi);
            list.Add(lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
            registrationList.Clear();
            registrationStrategy.Register(ref registrationList, lucaBianchi);
            registrationStrategy.Register(ref registrationList, marioRossi);
            registrationStrategy.Register(ref registrationList, lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
        }
    }
}
