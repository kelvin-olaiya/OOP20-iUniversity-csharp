using System;
using IUniversity.User;

namespace IUniversity.Didactics
{
    public interface Course
    {
        /**
         * Return a string with the name of the course
         */
        string GetName();
        /**
         * Return an int corresponding to the CFU
         */
        int GetCFU();
    }
}