namespace Planner.PresentationLayer.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string RoleName { get; set; }

        public string ImageSource { get; set; }

        public DepartmentViewModel[] Departments { get; set; }

        public RateViewModel[] Rates { get; set; }

        public SelectedDisciplinesViewModel[] SelectedDisciplines { get; set; }

    }
}
