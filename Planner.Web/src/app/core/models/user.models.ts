import { DepartmentViewModel } from './disciplines.models';

export class UserViewModel {
  id: string;
  ldapId: string;
  imageSource: string;
  roleName: string;
  rates: RateViewModel[];
  departments: DepartmentViewModel[];
  selectedDisciplines: SelectedDisciplinesViewModel[];
}

export class RateViewModel {
  id: string;
  value: string;
  departmentName: string;
}

export class SelectedDisciplinesViewModel {
  id: string;
  Name: string;
  Specialization: string;
  Course: string;
  ECTS: string;
  AmountOfHours: string;
  Language: string;
  WeeksInFirstSemester: string;
  WeeksInSecondSemester: string;
  AmountOfLecturesHours: string;
  Lectures: LectureViewModel[];
  AmountOfLaboratoriesHours: string;
  Laboratories: LaboratoryViewModel[];
  AmountOfPracticalsHours: string;
  Practicals: PracticalViewModel[];
  FormControl: string;
  DepartmentName: string;
}

export class PracticalViewModel {
  id: string;
  amountOfHours: string;
  selectedDisciplineId: string;
  userId: string;
}

export class LaboratoryViewModel {
  id: string;
  amountOfHours: string;
  selectedDisciplineId: string;
  userId: string;
}

export class LectureViewModel {
  id: string;
  amountOfHours: string;
  selectedDisciplineId: string;
  userId: string;
}

export class UserProfileModel {
  email: string;
  firstName: string;
  lastName: string;
  thirdName: string;
  scholarLink: string;
  orcidLink: string;
  degree: number;
  position: number;
  academicTitle: number;
  password: string;
  roleName: string;
  profilePicture: string;
  applicationUserId: string;
}
