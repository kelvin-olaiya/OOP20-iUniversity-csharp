using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    public interface ICourse
    {
        string Name { get; }
        int CFU { get; }
    }
}
