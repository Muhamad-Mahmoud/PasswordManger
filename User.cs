using System;
using System.IO;

namespace ConsoleApp3;

public static class User
{
    private static string UserName;
    private static string Password;
    private static bool Logged = false;

    public static void Login()
    {
        if (!File.Exists("UserInfo.txt")) 
        {
            Console.WriteLine("Please Sign Up first");
            return;
        }
        Console.WriteLine("============ Log In ============");
        Console.Write("Enter your name: ");
        UserName = Console.ReadLine();
        Console.Write("Enter your Password: ");
        string password = Console.ReadLine();

        if ((UserName + " " + password) == File.ReadAllText("UserInfo.txt"))
        {
            Logged = true;
        }
        else
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Username or Password is incorrect.");
            Console.WriteLine("-------------------------------");
            Login();
        }
    }

    public static void SignUp()
    {
        if (File.Exists("UserInfo.txt"))
        {
            Console.WriteLine("You are already Signed Up. Please Login.");
            Login();
        }
        else
        {
            Console.WriteLine("============ Sign Up ============");
            Console.Write("Enter your name: ");
            UserName = Console.ReadLine();
            Console.Write("Enter your Password: ");
            Password = Console.ReadLine();
            File.WriteAllText("UserInfo.txt", UserName + " " + Password);
            Logged = true;
        }
    }

    public static bool UserStatus()
    {
        return Logged;
    }
}
