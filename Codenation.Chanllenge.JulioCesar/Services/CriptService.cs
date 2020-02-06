using Codenation.Chanllenge.JulioCesar.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Services
{
    public class CriptService : ICriptService
    {
        public string DecriptJulioCesar(string value, int key)
        {
            value = value.ToLower();
            var valueAscii = Encoding.ASCII.GetBytes(value);

            byte[] result = new byte[value.Length];

            for (int i= 0;i<valueAscii.Length;i++)
            {
                if (valueAscii[i] > 96 && valueAscii[i] < 123)
                {
                    result[i] = Convert.ToByte(GetChar(valueAscii[i], key));
                }
                else
                {
                    result[i] = valueAscii[i];
                }
            }
            return Encoding.ASCII.GetString(result);
        }

        public string GetHashSha1(string value)
        {
            byte[] data = Encoding.Default.GetBytes(value);
            SHA1 sha = new SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(data);
            return BitConverter.ToString(result).Replace("-","");
        }

        private int GetChar(int charAscii, int key)
        {
            var result = charAscii + key;
            if (result > 122)
                return result - 26;
            else if (result < 97)
                return 122 -(96 - result);
            return result;   
        }
    }
}
