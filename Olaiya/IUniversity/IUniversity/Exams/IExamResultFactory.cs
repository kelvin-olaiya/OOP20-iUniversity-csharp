using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public interface IExamResultFactory
    {
        /// <summary>
        /// Get a Cum laude exam result
        /// </summary>
        /// <returns>An istance of exam result</returns>
        IExamResult SuccededCumLaude();
        /// <summary>
        /// Get a succeded exam result 
        /// </summary>
        /// <param name="result">numeric result</param>
        /// <returns></returns>
        IExamResult Suceeded(int result);
        /// <summary>
        /// Get a failed exam result
        /// </summary>
        /// <param name="result">numeric result</param>
        /// <returns></returns>
        IExamResult Failed(int result);
        /// <summary>
        /// Get a failed exam result
        /// </summary>
        /// <returns></returns>
        IExamResult Withdrawn();
        /// <summary>
        /// Get a declined exam result
        /// </summary>
        /// <param name="result">numeric result</param>
        /// <returns></returns>
        IExamResult Declined(int result);
    }
}
