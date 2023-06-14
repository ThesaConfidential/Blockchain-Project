//var builder = WebApplication.CreateBuilder(args);


using Blockchain_Project.Controllers;
using Blockchain_Project.Models;
using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        BlockchainController controller = new BlockchainController();
        controller.Run();
        //    BlocckChain chainn = new BlocckChain();

        //    chainn.AddTransaction("John", "Alice", 5.0);
        //    chainn.AddTransaction("Bob", "Alice", 2.0);

        //    chainn.MinerBLock("Miner1");

        //    Console.WriteLine("Blockchain: ");
        //    Console.WriteLine(chainn.ToString());
        //    Console.WriteLine();

        //    Console.WriteLine("Blockchain Validation: ");
        //    Console.WriteLine("Is Valid: " + chainn.IsValid);
        //    Console.WriteLine();

        //    chainn.AddTransaction("RareCo", "Selena", 3.0);
        //    chainn.AddTransaction("WonderM", "Selena", 5.0);
        //    chainn.AddTransaction("Selena", "WonderM", 4.0);
        //    chainn.MinerBLock("Miner2");

        //    Console.WriteLine("Updated Blockchain Validation:");
        //    Console.WriteLine(chainn.ToString());
        //    Console.WriteLine();


        //    Console.WriteLine("Update Blockchain validation:");
        //    Console.WriteLine("Is Valid: " + chainn.IsValid());
    }
}

