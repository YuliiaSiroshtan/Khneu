﻿using Planner.ServiceInterfaces.Interfaces.Сommon;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Planner.BusinessLogic.Service.Сommon
{
    public class SecurityService : ISecurityService
    {
        public string GetSha512Hash(string input)
        {
            using var hashAlgorithm = new SHA512CryptoServiceProvider();
            var byteValue = Encoding.UTF8.GetBytes(input);
            var byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}
