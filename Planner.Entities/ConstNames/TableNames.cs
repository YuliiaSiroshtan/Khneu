namespace Planner.Entities.ConstNames
{
    public static class TableNames
    {
        public static class User
        {
            public const string Users = "Users";
            public const string Roles = "Roles";
            public const string Rates = "Rates";
        }

        public static class EntryLoad
        {
            public const string FullTimeEntryLoads = "FullTimeEntryLoads";
            public const string PartTimeEntryLoads = "PartTimeEntryLoads";
            public const string EntryLoadsProperties = "EntryLoadsProperties";
            public const string UserEntryLoadsProperties = "UserEntryLoadsProperties";
        }

        public static class Disciplines
        {
            public const string FullTimeDisciplines = "FullTimeDisciplines";
            public const string PartTimeDisciplines = "PartTimeDisciplines";
            public const string SelectedDisciplines = "SelectedDisciplines";
        }

        public static class Semester
        {
            public const string FirstSemesters = "FirstSemesters";
            public const string SecondSemester = "SecondSemesters";
        }

        public static class UniversityUnit
        {
            public const string Faculties = "Faculties";
            public const string Departments = "Departments";
        }

        public static class Sessions
        {
            public const string ConstituentSessions = "ConstituentSessions";
            public const string ExaminationSessions = "ExaminationSessions";
        }

        public static class HoursCalculation
        {
            public const string HoursCalculationOfFirstSemesters = "HoursCalculationOfFirstSemesters";
            public const string HoursCalculationOfSecondSemesters = "HoursCalculationOfSecondSemesters";
        }

        public static class FormEducation
        {
            public const string Lectures = "Lectures";
            public const string Laboratories = "Laboratories";
            public const string Practicals = "Practicals";
        }
    }
}