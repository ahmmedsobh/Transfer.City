using System.ComponentModel;
using System.Reflection;
namespace Transfer.City.Extensions
{
    public class DisplaySiteTextAttribute : DisplayNameAttribute
    {
        private readonly string _key;
        public DisplaySiteTextAttribute(string key) => _key = key;
        public override string DisplayName => _key;
        public static string GetAttribute(MemberInfo m) => ((DisplayNameAttribute)GetCustomAttribute(m, typeof(DisplayNameAttribute))).DisplayName;
    }
}