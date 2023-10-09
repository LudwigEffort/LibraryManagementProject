using System;
using LibraryManagementApp.Core;
using System.IO;
using System.Reflection.Metadata;

class Library
{
    static void Main(string[] args)
    {
        // Menu.StartMenu();
        string line;
        try
        {
            StreamWriter OpenUsers = new StreamWriter(@"\database\Users", true);
            while ((line = OpenUsers.StreamReader()) != null)
            {
                Console.WriteLine(line);
            }
        
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}
