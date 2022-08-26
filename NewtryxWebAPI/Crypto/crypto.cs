using System;
using System.Text;

namespace NewtryxWebAPI.Crypto
{
    public static class crypto
    {
        public static string Hash(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                return Convert.ToBase64String(
                    System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value))
                    ) ;
            }
        }
    }
}
