using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    interface ICourse
    {
        string Name { get; }
        int CFU { get; }
    }
}
