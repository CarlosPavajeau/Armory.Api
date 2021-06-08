using System;
using System.Text;

namespace Armory.Shared.Domain
{
    public static class Utils
    {
        public static string StringToBase64(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string Base64ToString(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
