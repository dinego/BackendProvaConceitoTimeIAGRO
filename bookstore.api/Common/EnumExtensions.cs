using System;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);

            MemberInfo member = enumType.GetField(name);
            DescriptionAttribute attribute = member.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? name;
        }
    }
}