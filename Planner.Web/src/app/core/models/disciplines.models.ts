export class FullTimeDisciplinesViewModel {
  id: number;
  name: string;
  ECTS: string;
  amountOfHours: string;
  language: string;
  weeksInFirstSemester: string;
  weeksInSecondSemester: string;
  firstSemester: FirstSemesterViewModel;
  secondSemester: SecondSemesterViewModel;
  department: DepartmentViewModel;
}

export class PartTimeDisciplineViewModel {
  id: string;
  name: string;
  ECTS: string;
  amountOfHours: string;
  KRKPDR: string;
  language: string;
  numberOfDeaneryMembers: string;
  ConstituentSession: ConstituentSessionViewModel;
  examinationSession: ExaminationSessionViewModel;
  department: DepartmentViewModel;
}

export class FirstSemesterViewModel {
  id: string;
  hours: string;
  hoursAll: string;
  lectures: string;
  laboratory: string;
  practical: string;
  individualWork: string;
  courseWork: string;
  exam: string;
  credit: string;
}

export class SecondSemesterViewModel {
  id: string;
  hours: string;
  hoursAll: string;
  lectures: string;
  laboratory: string;
  practical: string;
  individualWork: string;
  courseWork: string;
  exam: string;
  credit: string;
}

export class DepartmentViewModel {
  id: string;
  name: string;
  codeDepartment: string;
  classification: string;
  facultyName: string;
}

export class ConstituentSessionViewModel {
  id: string;
  hours: string;
  hoursAll: string;
  lectures: string;
  laboratory: string;
  practical: string;
  individualWork: string;
  courseWork: string;
  controlWork: string;
  exam: string;
  credential: string;
}

export class ExaminationSessionViewModel {
  id: string;
  hours: string;
  hoursAll: string;
  lectures: string;
  laboratory: string;
  practical: string;
  individualWork: string;
  courseWork: string;
  controlWork: string;
  exam: string;
  credit: string;
}
