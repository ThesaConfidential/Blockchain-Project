using Blockchain_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Blockchain_Project.Controllers
{
    public class BlockchainController
    {
       
        private readonly BlocckChain blockchain;
        private Dictionary<string, Action> menuOptions;

        public BlockchainController()
        {
            blockchain = new BlocckChain();
            InitializeMenuOptions();
        }

        public void Run()
        {
            IEnumerator<Action> menuEnumerator = menuOptions.Values.GetEnumerator();

            while (true)
            {
                Console.Clear();
                DisplayMenu();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0")
                    break;

                if (menuOptions.TryGetValue(choice, out Action selectedOption))
                {
                    selectedOption.Invoke();
                    if (!menuEnumerator.MoveNext())
                        menuEnumerator = menuOptions.Values.GetEnumerator();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void InitializeMenuOptions()
        {
            menuOptions = new Dictionary<string, Action>
            {
                { "1", AddTransaction },
                { "2", MineBLock },
                { "3", DisplayBlockchain },
                { "4", ValidateBlockchain },
                { "0", ExitProgram }
            };
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Blockchain Menu:");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. Mine Block");
            Console.WriteLine("3. Display Blockchain");
            Console.WriteLine("4. Validate Blockchain");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        private void AddTransaction()
        {
            Console.Write("Enter sender: ");
            string sender = Console.ReadLine();

            Console.Write("Enter recipient: ");
            string recipient = Console.ReadLine();

            Console.Write("Enter amount: ");
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid amount. Please try again.");
                Console.Write("Enter amount: ");
            }

            blockchain.AddTransaction(sender, recipient, amount);
            Console.WriteLine("Transaction added successfully.");
        }

        private void MineBLock()
        {
            Console.Write("Enter miner name: ");
            string miner = Console.ReadLine();

            //blockchain.MineBLock(miner);
            Console.WriteLine("Block mined successfully.");
        }

        private void DisplayBlockchain()
        {
            Console.WriteLine("Blockchain:");
            Console.WriteLine(blockchain.ToString());
        }

        private void ValidateBlockchain()
        {
            bool isValid = blockchain.IsValid();
            Console.WriteLine("Blockchain Validation:");
            Console.WriteLine("Is Valid: " + isValid);
        }

        private void ExitProgram()
        {
            Environment.Exit(0);
        }
    }

}

