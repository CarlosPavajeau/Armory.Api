using System.Collections.Concurrent;
using System.Reflection;

namespace Armory.Shared.Helpers
{
    public static class AssemblyHelper
    {
        private static readonly ConcurrentDictionary<string, Assembly> Assemblies = new();

        public static Assembly GetInstance(string key)
        {
            return Assemblies.GetOrAdd(key, Assembly.Load(key));
        }
    }

    public static class Assemblies
    {
        public const string Armory = "Armory";
    }
}
