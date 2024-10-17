using System.Text;

namespace PasswordManager.PassworsManager
{
    internal class App
    {
        private static readonly Dictionary<string, string> _PasswordEntries = new();
        public static void Run(string[] args)
        {
            ReadPassword();
            while (true)
            {
                Console.WriteLine("Please Select an option: ");
                Console.WriteLine("1. List all passwords");
                Console.WriteLine("2. Add/Change Password");
                Console.WriteLine("3. Get Password");
                Console.WriteLine("4. Delete Password");
                var selectedOption = Console.ReadLine();
                if (selectedOption == "1")
                    ListAllPasswords();
                else if (selectedOption == "2")
                    AddOrChangePassword();
                else if (selectedOption == "3")
                    GetPassowrd();
                else if (selectedOption == "4")
                    DeletePassword();
                else Console.WriteLine("InValid Option");

                Console.WriteLine("*******************************************");
            }

        }



        private static void DeletePassword()
        {
            Console.WriteLine("Please Enter the website/app name: ");
            var appName = Console.ReadLine();
            if (_PasswordEntries.ContainsKey(appName))
            {
                _PasswordEntries.Remove(appName);
                Console.WriteLine("your password deleted");
                SavePasswords();
            }
            else
            {
                Console.WriteLine("Password not found");
            }
        }

        private static void GetPassowrd()
        {
            Console.WriteLine("Please Enter App/Website name: ");
            var appName = Console.ReadLine();
            if (_PasswordEntries.ContainsKey(appName))
                Console.WriteLine($"Your Password = {_PasswordEntries[appName]}");
            else Console.WriteLine("Password not founded");
        }

        private static void AddOrChangePassword()
        {
            Console.WriteLine("PLease Enter the website/app name: ");
            var appName = Console.ReadLine();
            Console.WriteLine("Please Enter your Password: ");
            var password = Console.ReadLine();
            if (_PasswordEntries.ContainsKey(appName))
            {
                _PasswordEntries[appName] = password;
            }
            else
            {
                _PasswordEntries.Add(appName, password);
            }
            SavePasswords();

        }

        private static void ListAllPasswords()
        {
            foreach (var entry in _PasswordEntries)
            {
                Console.WriteLine($"{entry.Key} = {entry.Value}");
            }
        }
        private static void ReadPassword()
        {
            if (File.Exists("passwords.txt"))
            {
                var passwordLines = File.ReadAllText("passwords.txt");
                foreach (var line in passwordLines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var equalIndex = line.IndexOf('=');
                        var appName = line.Substring(0, equalIndex);
                        var password = line.Substring(equalIndex + 1);
                        _PasswordEntries.Add(appName, EncryptionUtility.Decrypt(password));
                    }
                }
            }
        }
        private static void SavePasswords()
        {
            var sb = new StringBuilder();
            foreach (var entry in _PasswordEntries)
                sb.AppendLine($"{entry.Key} = {EncryptionUtility.Encrypt(entry.Value)}");
            File.WriteAllText("password.txt", sb.ToString());
        }
    }
}

