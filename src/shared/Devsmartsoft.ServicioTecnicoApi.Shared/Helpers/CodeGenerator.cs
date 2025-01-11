using System.Text;

namespace Devsmartsoft.ServicioTecnicoApi.Shared.Helpers
{
    public static class CodeGenerator
    {
        private static readonly Random Random = new Random();
        private const string AlphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string FirstNumericCharacters = "123456789"; // Excludes zero for the first character
        private const string AllNumericCharacters = "0123456789"; // Includes zero for subsequent characters

        public static string GenerateRandomCode(int length, bool numericOnly)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be a positive number", nameof(length));

            var result = new StringBuilder(length);

            if (numericOnly)
            {
                // Ensure the first character is not zero
                result.Append(FirstNumericCharacters[Random.Next(FirstNumericCharacters.Length)]);
                for (int i = 1; i < length; i++)
                {
                    result.Append(AllNumericCharacters[Random.Next(AllNumericCharacters.Length)]);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    result.Append(AlphanumericCharacters[Random.Next(AlphanumericCharacters.Length)]);
                }
            }

            return result.ToString();
        }
    }
}
