using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Enums
{
    public enum PublicationTypeEnum
    {
        Abstracts = 1,
        Article = 2,
        ScientificReport = 3,
        Patent = 4,
        Tutorial = 5,
        LaboratoryWorkshop = 6,
        Monograph = 7,
        WorkProgram = 8,
        EducationalAndPracticalGuide = 9,
        CollectiveMonograph = 10,
        ElectronicTextbook = 11
    }

    public static class PublicationTypeEnumExtensions
    {
        public static string GetDescription(this PublicationTypeEnum value)
        {
            if (value == PublicationTypeEnum.Abstracts)
            {
                return "Тези доповіді";
            }
            if (value == PublicationTypeEnum.Article)
            {
                return "Стаття";
            }
            if (value == PublicationTypeEnum.ScientificReport)
            {
                return "Звіт про НДР";
            }
            if (value == PublicationTypeEnum.Patent)
            {
                return "Патент";
            }
            if (value == PublicationTypeEnum.Tutorial)
            {
                return "Навчальний посібник";
            }
            if (value == PublicationTypeEnum.LaboratoryWorkshop)
            {
                return "Лабораторний практикум";
            }
            if (value == PublicationTypeEnum.Monograph)
            {
                return "Монографія";
            }
            if (value == PublicationTypeEnum.WorkProgram)
            {
                return "Робоча програма";
            }
            if (value == PublicationTypeEnum.EducationalAndPracticalGuide)
            {
                return "Навчально-практичний поcібник";
            }
            if (value == PublicationTypeEnum.CollectiveMonograph)
            {
                return "Коллективная монография";
            }
            if (value == PublicationTypeEnum.ElectronicTextbook)
            {
                return "Електронний навчальний посібник";
            }
            return "";
        }
    }
}
