using System;

namespace FirstTryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to the database console interface");
            Console.WriteLine("Your choice of commands are:" +
                              "\n\"1\" : Create database, wipe if one already exists" +
                              "\n\"2\" : Seed Database with DummyData(TODO)" +
                              "\n\"3\" : Pull Example Data from Database(TODO)" +
                              "\n\"4\" : Destroy database");
            do
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Commands.CreateDatabase();
                        Console.WriteLine("Database successfully created");
                        break;

                    case "2":
                        //Commands.ListAllWithLogs();
                        break;

                    case "3":
                        //Commands.ListAllWithLogs();
                        break;

                    case "4":
                        Commands.DestroyDatabase();
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            } while (true);
        }
    }
}
