using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp3;

public static class PasswordManger
{
    public static Dictionary<string, string> UserPasswords = new();

    public static void AddOrChangePassword()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Add or Change Password");
        Console.WriteLine("----------------------");
        Console.Write("Please enter website/app name: ");
        string website = Console.ReadLine()?.Trim();
        Console.Write("Please enter Password: ");
        string password = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(website) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Website or Password cannot be empty.");
            return;
        }

        if (UserPasswords.ContainsKey(website))
            UserPasswords[website] = password;
        else
            UserPasswords.Add(website, password);

        SavePasswords();
        Console.WriteLine("Website added/updated successfully.");
        Console.WriteLine("-----------------------------------");
    }

    public static void GetPassword()
    {
        Console.WriteLine("--------------");
        Console.WriteLine("Get Password");
        Console.WriteLine("--------------");
        Console.Write("Please enter website/app name: ");
        string website = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(website))
        {
            Console.WriteLine("Website cannot be empty.");
            return;
        }

        if (UserPasswords.TryGetValue(website, out var password))
        {
            Console.WriteLine($"The Password for {website} -> {password}");
            Console.WriteLine("----------------------------------------------");
        }
        else
        {
            Console.WriteLine($"No password found for {website}.");
            Console.WriteLine("----------------------------");
        }
    }

    public static void DeletePassword()
    {
        Console.WriteLine("--------------");
        Console.WriteLine("Delete Password");
        Console.WriteLine("--------------");
        Console.Write("Please enter website/app name to delete: ");
        string website = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(website))
        {
            Console.WriteLine("Website cannot be empty.");
            return;
        }

        if (UserPasswords.Remove(website))
        {
            Console.WriteLine($"Password for {website} deleted successfully.");
            Console.WriteLine("-------------------------------");
            SavePasswords();
        }
        else
        {
            Console.WriteLine($"No password found for {website}.");
            Console.WriteLine("-------------------------------");
        }
    }

    public static void ListAllPasswords()
    {
        Console.WriteLine("--------------");
        Console.WriteLine("List All Passwords");
        Console.WriteLine("--------------");
        if (UserPasswords.Count == 0)
        {
            Console.WriteLine("There are no passwords.");
            Console.WriteLine("----------------------");
            return;
        }

        int idx = 1;
        foreach (var entry in UserPasswords)
        {
            Console.WriteLine($"Password {idx}: {entry.Key} -> {entry.Value}");
            idx++;
        }
        Console.WriteLine("-------------------------------------");
    }

    public static void ReadAllPasswords()
    {
        if (!File.Exists("Passwords.txt")) return;

        var passwordLines = File.ReadAllText("Passwords.txt");
        foreach (var line in passwordLines.Split(Environment.NewLine))
        {
            if (!string.IsNullOrEmpty(line))
            {
                var equalIndex = line.IndexOf('=');
                if (equalIndex > 0)
                {
                    var appName = line.Substring(0, equalIndex);
                    var password = line.Substring(equalIndex + 1);
                    UserPasswords[appName] = Encreption.Decrept(password);
                }
            }
        }
    }

    public static void SavePasswords()
    {
        var sb = new StringBuilder();
        foreach (var pass in UserPasswords)
        {
            sb.AppendLine($"{pass.Key}={Encreption.Encrept(pass.Value)}");
        }

        File.WriteAllText("Passwords.txt", sb.ToString());
    }
}
