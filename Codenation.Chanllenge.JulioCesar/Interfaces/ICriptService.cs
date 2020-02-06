using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Interfaces
{
    public interface ICriptService
    {
        string DecriptJulioCesar(string value, int key);
        string GetHashSha1(string value);
    }
}
