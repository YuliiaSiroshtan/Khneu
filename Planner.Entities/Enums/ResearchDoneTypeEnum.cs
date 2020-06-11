using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Enums
{
    public enum ResearchDoneTypeEnum
    {
        StateBudget = 1,
        ContractualTopic = 2,
        ForIndividualTeacherPlan = 3,
        Other = 4
    }

    public static class ResearchDoneTypeEnumExtensions
    {
        public static string GetDescription(this ResearchDoneTypeEnum value)
        {
            if (value == ResearchDoneTypeEnum.StateBudget)
            {
                return "Держбюджет";
            }
            if (value == ResearchDoneTypeEnum.ContractualTopic)
            {
                return "Госпдоговірна тема";
            }
            if (value == ResearchDoneTypeEnum.ForIndividualTeacherPlan)
            {
                return "За індивідуальним планом викладача";
            }
            if (value == ResearchDoneTypeEnum.Other)
            {
                return "Iншi";
            }
            return "";
        }
    }
}
