using System;
using LLVMSharp;

namespace Baja
{
    class Program
    {
        public static Properties BuildProps;

        static void Main(string[] args)
        {
            // Create a new Properties container
            BuildProps = new Properties();

            // Check for arguments. If none given, check for a BajaProject.toml
            if (args.Length == 0)
            {
                // TODO: Add a method to check for BajaProject.toml
                throw new ArgumentException("Error: No arguments given.");
            }

            // Debug check for all commands
            /*
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            */

            // Switch of First Command
            switch(args[0])
            {
                case "build":
                    for (int i = 1; i < args.Length; i++)
                    {
                        switch (args[i])
                        {
                            case "-Warn":
                                // Do a quick check for a number after -Warn
                                if (args.Length < i + 1)
                                {
                                    throw new ArgumentException("Error: Value required for -Warn level");
                                }

                                string WarnNumber = args[i + 1];
                                int WarnNum = Convert.ToInt32(WarnNumber);
                                BuildProps.WarnLevel = WarnNum;
                                i++;
                                break;
                            case "-Opt":
                                // Do a quick check for a number after -Opt
                                if (args.Length < i + 1)
                                {
                                    throw new ArgumentException("Error: Value required for -Opt level");
                                }

                                string OptNumber = args[i + 1];
                                int OptNum = Convert.ToInt32(OptNumber);
                                BuildProps.OptLevel = OptNum;
                                i++;
                                break;
                            case "-Name":
                                // Do a quick check for a number after -Name
                                if (args.Length < i + 1)
                                {
                                    throw new ArgumentException("Error: Value required for -Name");
                                }

                                string NameValue = args[i + 1];
                                BuildProps.Name = NameValue;
                                i++;
                                break;
                            default:
                                if (args[i].EndsWith(".baja"))
                                {
                                    Console.WriteLine("Baja file detected! File: {0}", args[i]);
                                } else
                                {
                                    Console.WriteLine("Error: Invalid argument for build command.");
                                }
                                break;
                        }
                    }
                    break;
                default:
                    string CurrentInput = args[0];
                    Console.WriteLine("Error: Invalid argument: {0}", CurrentInput);
                    break;
            }

            Console.WriteLine("WarnLevel: {0}", BuildProps.WarnLevel);
            Console.WriteLine("OptLevel: {0}", BuildProps.OptLevel);
            Console.WriteLine("Project Name: {0}", BuildProps.Name);
        }
    }
}
