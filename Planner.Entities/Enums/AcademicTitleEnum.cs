using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Enums
{
    public enum AcademicTitleEnum
    {
        CandidateOfScience = 1, // Кандидат наук
        DoctorOfScience = 2//Доктор наук


    }

    public static class AcademicTitleEnumExtensions
    {
        public static string GetDescription(this AcademicTitleEnum value)
        {
            if (value == AcademicTitleEnum.CandidateOfScience)
            {
                return "Кандидат наук";
            }
            if (value == AcademicTitleEnum.DoctorOfScience)
            {
                return "Доктор наук";
            }
            return "";
        }
    }
    
}
