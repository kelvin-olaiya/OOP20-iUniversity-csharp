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
        private StudentRegistrationStrategyFactory strategyFactory = new StudentRegistrationStrategyFactory();
        private SampleData sd = new SampleData();
        private IStudent marioRossi;
        private IStudent lucianoVerdi;
        private IStudent lucaBianchi;

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
            registrationStrategy.register(ref registrationList, marioRossi);
            registrationStrategy.register(ref registrationList, lucaBianchi);
            registrationStrategy.register(ref registrationList, lucianoVerdi);
            list.Add(lucianoVerdi);
            list.Add(lucaBianchi);
            list.Add(marioRossi);
            Assert.True(registrationList.SequenceEqual(list));
            registrationList.Clear();
            list.Clear();
            registrationStrategy.register(ref registrationList, lucaBianchi);
            registrationStrategy.register(ref registrationList, marioRossi);
            registrationStrategy.register(ref registrationList, lucianoVerdi);
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
            registrationStrategy.register(ref registrationList, marioRossi);
            registrationStrategy.register(ref registrationList, lucaBianchi);
            registrationStrategy.register(ref registrationList, lucianoVerdi);
            list.Add(marioRossi);
            list.Add(lucaBianchi);
            list.Add(lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
            registrationList.Clear();
            list.Clear();
            registrationStrategy.register(ref registrationList, lucaBianchi);
            registrationStrategy.register(ref registrationList, marioRossi);
            registrationStrategy.register(ref registrationList, lucianoVerdi);
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
            registrationStrategy.register(ref registrationList, marioRossi);
            registrationStrategy.register(ref registrationList, lucaBianchi);
            registrationStrategy.register(ref registrationList, lucianoVerdi);
            list.Add(lucaBianchi);
            list.Add(marioRossi);
            list.Add(lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
            registrationList.Clear();
            registrationStrategy.register(ref registrationList, lucaBianchi);
            registrationStrategy.register(ref registrationList, marioRossi);
            registrationStrategy.register(ref registrationList, lucianoVerdi);
            Assert.True(registrationList.SequenceEqual(list));
        }
    }
}
