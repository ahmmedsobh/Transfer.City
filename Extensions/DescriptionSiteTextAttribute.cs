using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Transfer.City.Extensions
{
    public class DescriptionSiteTextAttribute : DescriptionAttribute
    {
        private readonly string _key;
        public DescriptionSiteTextAttribute(string key) => _key = key;
        public override string Description => _key;
        public static string GetAttribute(MemberInfo m) => ((DescriptionSiteTextAttribute)GetCustomAttribute(m, typeof(DescriptionSiteTextAttribute))).Description;
    }
}