using System;
using System.Runtime.CompilerServices;

namespace FirstTryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to the database console interface");
            Console.WriteLine("Your choice of commands are:" +
                              "\n\"1\" : Create database" +
                              "\n\"2\" : Put valid dummy data into database" +
                              "\n\"3\" : Put a invalid dummy data into database" +
                              "\n\"3\" : Empty database");
            do
            {
                try
                {
                    Console.Write("> ");
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            if (Commands.CreateDatabase())
                            {
                                Console.WriteLine("Database successfully created");
                            }
                            else
                            {
                                Console.WriteLine("Database did not get created");
                            }
                            break;

                        case "2":
                            Commands.SeedDatabase();
                            break;

                        case "3":
                            Commands.SeedDatabaseWrong();
                            break;

                        case "4":
                            Commands.EmptyDatabase();
                            break;

                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid database request" +
                                      "\nWant to review exeption?" +
                                      "\ny/n");
                    string answer = Console.ReadLine();
                    if(answer == "y" || answer == "Y")
                        Console.WriteLine(e);
                    else if (answer == "n" || answer == "N"){}
                    else
                    {
                        Console.WriteLine("Invalid command, try again");
                    }

                }
                
            } while (true);
        }
    }
}
