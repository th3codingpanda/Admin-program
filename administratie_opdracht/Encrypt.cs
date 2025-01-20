using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;


namespace administratie_opdracht
{
    internal class Encrypt
    {
        public string encrypt(string password)
        {
            password = CalculateSHA256(password);
            string output = "";
            foreach (char c in password)
            {
                char encrypted = (char)(c + 1);
                output += encrypted;
            }
            return (output);
        }
        private string CalculateSHA256(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashValue)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }
    }
}
