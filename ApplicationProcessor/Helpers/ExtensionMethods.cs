using System;
using System.ComponentModel;
using System.Reflection;

namespace ULaw.ApplicationProcessor
{
    static class ExtensionMethods
    {
        public static string ToDescription(this Enum enumerationValue)
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum) throw new ArgumentException("Value must be of Enum type", "enumerationValue");
            
            MemberInfo[] memInfo = type.GetMember(enumerationValue.ToString());

            if (memInfo.Length <= 0) return enumerationValue.ToString();
            
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs.Length > 0) return ((DescriptionAttribute)attrs[0]).Description;
            
            return enumerationValue.ToString();
        }
    }
}
