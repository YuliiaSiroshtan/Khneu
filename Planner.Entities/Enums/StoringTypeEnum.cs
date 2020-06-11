using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Enums
{
    public enum StoringTypeEnum
    {
        Print = 1,
        Electronic = 2
    }

    public static class StoringTypeEnumExtensions
    {
        public static string GetDescription(this StoringTypeEnum value)
        {
            if (value == StoringTypeEnum.Print)
            {
                return "Друковане видання";
            }
            if (value == StoringTypeEnum.Electronic)
            {
                return "Електронне видання";
            }
            return "";
        }
    }
}
