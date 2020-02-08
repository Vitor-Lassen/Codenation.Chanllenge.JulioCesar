using Codenation.Chanllenge.JulioCesar.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Repositories
{
    public class FileRepository<TEntity> : IFileRepository<TEntity>
        where TEntity : class
    {
        public bool SaveFile(string fileName, string path, TEntity entity)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            { NullValueHandling = NullValueHandling.Ignore };
            
            string data = JsonConvert.SerializeObject(entity, Formatting.Indented, jsonSerializerSettings);
            using (StreamWriter streamWriter =
                   new StreamWriter($@"{path}\{fileName}.json", false, Encoding.ASCII))
            {
                streamWriter.Write(data);
                streamWriter.Dispose();
            }
            return true;
        }
    }
}

