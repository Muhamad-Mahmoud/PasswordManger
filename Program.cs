namespace ConsoleApp3;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("------------- Welcome to Password Manager App -------------");
        Console.WriteLine("Choose An Option: \n   1. Signup\n   2. Login");

        while (!User.UserStatus())
        {
            var input = Console.ReadLine();
            if (input == "1")
                User.SignUp();
            else if (input == "2")
                User.Login();
            else
                Console.WriteLine("Choose a Valid Option: \n   1. Signup\n   2. Login");
        }

        Console.WriteLine("User Logged in Successfully");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("------------- Password Manager App -------------");
        Console.WriteLine("-----------------------------------------------");

        while (true)
        {
            Console.WriteLine("Select An Option");
            Console.WriteLine(" 1. List All Passwords");
            Console.WriteLine(" 2. Add or Change Password");
            Console.WriteLine(" 3. Get Password");
            Console.WriteLine(" 5. Delete Password");
            Console.WriteLine(" 6. Exit");

            if (!int.TryParse(Console.ReadLine(), out var option))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }
            PasswordManger.ReadAllPasswords();
            switch (option)
            {
                case 1:
                    PasswordManger.ListAllPasswords();
                    break;
                case 2:
                    PasswordManger.AddOrChangePassword();
                    break;
                case 3:
                    PasswordManger.GetPassword();
                    break;
                case 5:
                    PasswordManger.DeletePassword();
                    break;
                case 6:
                    Console.WriteLine("Exiting Password Manager. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }
}
