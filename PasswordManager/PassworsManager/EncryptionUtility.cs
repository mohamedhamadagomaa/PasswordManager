using System.Text;

namespace PasswordManager.PassworsManager
{
    internal class EncryptionUtility
    {
        private static readonly string _allChars = "ABCDEFGHIGKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz0123456789";
        private static readonly string _altChars = "F2bDHi4YVQu7TUxhmfsq6tkXwl10zNy98nSAPIvjhkwkjqegxceqeuiswmklbc";
        public static string Encrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (char c in password)
            {
                var charIndex = _allChars.IndexOf(c);
                sb.Append(_altChars[charIndex]);
            }
            return sb.ToString();
        }
        public static string Decrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (char c in password)
            {
                var charIndex = _altChars.IndexOf(c);
                sb.Append(_allChars[charIndex]);
            }
            return sb.ToString();


        }
    }
}
