using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Enums
{
    public enum PositionEnum
    {
        HeadDepartment = 1,
        DocentDepartment = 2,
        SeniorLecturer = 3,
        Lecturer = 4,
        Assistant = 5
    }

    public static class PositionEnumExtensions
    {
        public static string GetDescription(this PositionEnum value)
        {
            if (value == PositionEnum.HeadDepartment)
            {
                return "Завідуючий кафедрою";
            }
            if (value == PositionEnum.DocentDepartment)
            {
                return "Доцент кафедрою";
            }
            if (value == PositionEnum.SeniorLecturer)
            {
                return "Старший викладач кафедри";
            }
            if (value == PositionEnum.Lecturer)
            {
                return "Викладач кафедри";
            }
            if (value == PositionEnum.Assistant)
            {
                return "Асистент";
            }
            return "";
        }
    }
}
