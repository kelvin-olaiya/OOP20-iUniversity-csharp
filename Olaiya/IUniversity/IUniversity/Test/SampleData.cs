using System;
using System.Collections.Generic;
using System.Text;
using IUniversity.Entities;

namespace IUniversity.Test
{
    class SampleData
    {

        private readonly ICourse analisiMatematica;
        private readonly ICourse programmazione;
        private readonly ICourse algebra;
        private readonly IStudent marioRossi;
        private readonly IStudent lucianoVerdi;
        private readonly IStudent lucaBianchi;

        public SampleData()
        {
            analisiMatematica = new Course("Analisi Matematica", 12);
            programmazione = new Course("Programmazione", 12);
            algebra = new Course("Algebra", 6);
            marioRossi = new Student("Mario", "Rossi", "stu.rossi.mario", 1, 1);
            lucianoVerdi = new Student("Luciano", "Verdi", "stu.rossi.mario", 2, 2);
            lucaBianchi = new Student("Luca", "Bianchi", "stu.rossi.mario", 3, 3);
        }

        public ICourse AnalisiMatematica
        {
            get => analisiMatematica;
        }

        public ICourse Programmazione
        {
            get => programmazione;
        }

        public ICourse Algebra
        {
            get => algebra;
        }

        public IStudent MarioRossi
        {
            get => marioRossi;
        }

        public IStudent LucianoVerdi
        {
            get => lucianoVerdi;
        }

        public IStudent LucaBianchi
        {
            get => lucaBianchi;
        }
    }
}
