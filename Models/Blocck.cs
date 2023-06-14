using NuGet.Packaging.Signing;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain_Project.Models
{
    public class Blocck
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string PreviousHash { get; set; }
        public string []Transaction { get; set; }
        public string Hash { get; set; }  
        public int Nonce { get; set; }  


        public Blocck(int index, DateTime timestamp, string previousHash, string[] transaction)
        {
            Index = index;
            Timestamp = timestamp;
            PreviousHash = previousHash;
            Transaction = transaction;
            Hash = MinerBLock();
            Nonce = 0;

        }

        public string ComputHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string data = $"{Index}-{Timestamp}-{PreviousHash}-{string.Join(", ", Transaction)}-{Nonce}";
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                StringBuilder Builder = new StringBuilder();
                
                for (int x = 0; x < hashBytes.Length; x++)
                {
                    Builder.Append(hashBytes[x].ToString("x2"));
                }
                return Builder.ToString();
            }
        }
            
        public string MinerBLock()
        {

            string targetPrefix = "0000";
            string hash = ComputHash() ;

            while (!hash.StartsWith(targetPrefix))
            {
                Nonce++;
                hash = ComputHash();
            }
            return hash;

                
        }
    }
}
