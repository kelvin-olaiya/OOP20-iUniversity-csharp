using System;
using IUniversity.User;

namespace IUniversity.Didactics
{
	public interface AcademicYear
    {
        /**
         * return the start date of the academic year
         */
        DateTime GetStart();

        /**
         * return the end date of the academic year
         */
        DateTime GetEnd();

        /**
         * return the start date of the first time
         */
        DateTime GetFirstTermStart();

        /**
         * return the end date of the first term
         */
        DateTime GetFirstTermEnd();

        /**
         * return the start date of the second term
         */
        DateTime GetSecondTermStart();

        /**
         * return the end date of the second term
         */
        DateTime GetSecondTermEnd();
    }
}