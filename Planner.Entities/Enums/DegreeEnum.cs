using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Enums
{
    public enum DegreeEnum
    {
        Docent = 1,
        SeniorResearchFellow = 2,
        Professor = 3
    }

    public static class DegreeEnumExtensions
    {
        public static string GetDescription(this DegreeEnum value)
        {
            if (value == DegreeEnum.Docent)
            {
                return "Доцент";
            }
            if (value == DegreeEnum.SeniorResearchFellow)
            {
                return "Старший науковий співробітник";
            }
            if (value == DegreeEnum.Professor)
            {
                return "Професор";
            }
            return "";
        }
    }
}
