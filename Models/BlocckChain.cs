using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

namespace Blockchain_Project.Models
{
    public class BlocckChain
    {
        private List<Blocck> blocck;
        private List<String> currentTansaction;

        public BlocckChain() 
        {
            blocck = new List<Blocck>();
            currentTansaction = new List<String>();
            CreateGenesisBlock();
        }

        private void CreateGenesisBlock()
        {
            Blocck GenesisBlock = new Blocck(0, DateTime.Now, "0", new string[] {});
            blocck.Add(GenesisBlock);
        }

        public void AddTransaction(string sender, string recipient, double amount)
        {
            string transaction = $"{sender} -> {recipient}: {amount}";
            currentTansaction.Add(transaction);
        }

        public void MinerBLock(string miner)
        {
            Blocck lastBlock  = blocck[blocck.Count - 1];
            int index = blocck.Count;
            DateTime timestamp = DateTime.Now;
            string previousHash = lastBlock.Hash;
            string[] transaction = currentTansaction.ToArray();


            Blocck newBlocck = new Blocck (index, timestamp, previousHash,transaction);
            
            //newBlocck.MinerBLock(miner);

            blocck.Add(newBlocck);

            currentTansaction.Clear();
        }

        public bool IsValid()
        {
            for (int x = 1; x < blocck.Count; x++)
            {
                Blocck currentBlocck = blocck[x];
                Blocck previoiusBlock = blocck[x - 1];  
                if(currentBlocck.Hash!= currentBlocck.ComputHash())
                    return false;

                if (currentBlocck.PreviousHash != previoiusBlock.Hash)
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(Blocck blocckK  in blocck) 
            {
                stringBuilder.Append(blocckK.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
