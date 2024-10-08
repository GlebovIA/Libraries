﻿using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Libraries.Classes.Common
{
    public class Hasher
    {
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }
    }
}
