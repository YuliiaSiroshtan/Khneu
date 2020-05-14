export class DayDistributionModel {
  semester: number;
  lecture: number;
  practice: number;
  lab: number;
  consultInSemester: number;
  consultForExam: number;
  verifyingOfTests: number;
  kr_kp: number;
  controlEvaluation: number;
  controlExam: number;
  practicePreparation: number;
  dek: number;
  stateExam: number;
  managedDiploma: number;
  other: number;
  total: number;
  active: number;
  englishBonus: number;
}

export class DayEntryModel {
  dayEntryId: string;
  faculty: string;
  specialty: string;
  specialization: string;
  course: string;
  educationDegree: string;
  studentsCount: number;
  foreignersCount: number;
  groupsCipher: string;
  quantityOfGroupsA: number;
  realQuantityOfGroups: number;
  quantityOfThreads: number;
  conflatedThreads: string;
  notes: string;
  subject: string;
  quantityOfCredits: string;
  hours: number;
  language: string;
  quantityOfWeeksFs: number;
  quantityOfWeeksSs: number;
  coeficientFs: number;
  coeficientSs: number;
  departmentCipher: string;
  projects: number;
  practices: number;
  quantityOfMembers: number;
  dayTeachId: string;
  daySemesterId: string;

  des: DesModel;
  dd: DayDistributionModel;

  constructor() {
    this.dayEntryId = null;
    this.faculty = null;
    this.specialty = null;
    this.specialization = null;
    this.course = null;
    this.educationDegree = null;
    this.studentsCount = null;
    this.foreignersCount = null;
    this.groupsCipher = null;
    this.quantityOfGroupsA = null;
    this.realQuantityOfGroups = null;
    this.quantityOfThreads = null;
    this.conflatedThreads = null;
    this.notes = null;
    this.subject = null;
    this.quantityOfCredits = null;
    this.hours = null;
    this.language = null;
    this.quantityOfWeeksFs = null;
    this.quantityOfWeeksSs = null;
    this.coeficientFs = null;
    this.coeficientSs = null;
    this.departmentCipher = null;
    this.projects = null;
    this.practices = null;
    this.quantityOfMembers = null;
    this.dayTeachId = null;
    this.daySemesterId = null;
  }
}

export class DesModel {
  totalHours: number;
  total: number;
  lectures: number;
  labs: number;
  practices: number;
  independentWorks: number;
  courses: number;
  exam: string;
  evaluation: string;
}

export class DistributionFilterModel {
  year: number;
  semester: number;

  constructor() {
    this.year = 2017;
    this.semester = 1;
  }
}
