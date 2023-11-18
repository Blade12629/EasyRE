using EasyRE.EasyUO;
using EasyRE.EasyUO.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRE
{
    public static class Core
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            try
            {
                string scriptPath = @"C:\Repos\VM_LootSkript_edited.euo";
                EUOParser parser = EUOParser.FromFile(scriptPath);

                List<string> undefinedStatements = new List<string>();

                foreach (IStatement statement in parser.Statements)
                {
                    if (statement is not UndefinedStatement)
                        continue;

                    string statementStart = statement.ToString().Split(' ')[2];

                    if (!undefinedStatements.Contains(statementStart))
                    {
                        undefinedStatements.Add(statementStart);
                        Log(statement);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            Log("Done");

        }

        public static void Log(object obj)
        {
            Log(obj.ToString());
        }

        public static void Log(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void LogError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.ToString());
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
