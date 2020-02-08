using Codenation.Chanllenge.JulioCesar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Interfaces
{
    public interface ICodenationService
    {
        CriptDTO GetCript(string token);
        string SendFileDecript(string path, string fileName, string token);

    }
}
