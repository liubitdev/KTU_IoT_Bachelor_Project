using System;
using System.Linq;

namespace Device_Emulator_App.Models.Utils
{
    static class RandomGenerator
    {
        private static Random random = new Random();
        public static string GenerateRandomString(int stringLength)
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnm0123456789";
            return new string(Enumerable.Repeat(chars, stringLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
