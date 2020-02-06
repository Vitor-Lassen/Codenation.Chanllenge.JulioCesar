using Codenation.Chanllenge.JulioCesar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Interfaces
{
    public interface ICodenationService
    {
        Cript GetCript(string token);
        bool SendFileDecript(string FileLocation);

    }
}
