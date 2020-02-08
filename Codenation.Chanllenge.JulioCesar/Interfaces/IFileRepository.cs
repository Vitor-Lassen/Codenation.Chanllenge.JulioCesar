using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Interfaces
{
    public interface IFileRepository <TEntity>
        where TEntity :class
    {
        bool SaveFile(string fileName, string path, TEntity entity);
    }
}
