export class IndivPlanFieldsValueModel {
  indivPlanFieldsValueId: string;
  schemaName: string;
  plannedValue: string;
  result: string;
  applicationUserId: string;

  constructor() {
    this.indivPlanFieldsValueId = null;
    this.schemaName = null;
    this.plannedValue = null;
    this.result = null;
    this.applicationUserId = null;
  }
}

export class IndivPlanFieldModel {
  indivPlanFieldsId: string;
  displayName: string;
  schemaName: string;
  suffix: string;
  tabName: string;
  indPlanTypeId: string;
  plannedValue: number;
  result: number;

  constructor() {
    this.indivPlanFieldsId = null;
    this.displayName = null;
    this.schemaName = null;
    this.suffix = null;
    this.tabName = null;
    this.indPlanTypeId = null;
  }
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

  constructor() {
      this.email = null;
      this.firstName = null;
      this.lastName = null;
      this.thirdName = null;
      this.scholarLink = null;
      this.orcidLink = null;
      this.degree = null;
      this.position = null;
      this.academicTitle = null;
      this.password = null;
      this.roleName = null;
      this.profilePicture = null;
      this.applicationUserId = null;
  }

}

export class TrainingJobModel {
  id: string;
  educationForm: string;
  orderNumber: number;
  subject: string;
  dsd: string;
  course: number;
  countStudent: number;
  groupCode: string;
  plannedLectures: number;
  doneLectures: number;
  plannedPract: number;
  donePract: number;
  plannedLaboratory: number;
  doneLaboratory: number;
  plannedSeminar: number;
  doneSeminar: number;
  plannedIndividual: number;
  doneIndividual: number;
  plannedConsultation: number;
  doneConsultation: number;
  plannedExamConsultation: number;
  doneExamConsultation: number;
  plannedCheckControl: number;
  doneCheckControl: number;
  plannedCheckLectureControl: number;
  doneCheckLectureControl: number;
  plannedEAT: number;
  doneEAT: number;
  plannedCGS: number;
  doneCGS: number;
  plannedCoursework: number;
  doneCoursework: number;
  plannedOffsetting: number;
  doneOffsetting: number;
  plannedSemestrExam: number;
  doneSemestrExam: number;
  plannedTrainingPract: number;
  doneTrainingPract: number;
  plannedStateExam: number;
  doneStateExam: number;
  plannedDiploma: number;
  doneDiploma: number;
  plannedPostgraduates: number;
  donePostgraduates: number;
  plannedDEK: number;
  doneDEK: number;
  applicationUserId: string;

  constructor() {
    this.id = null;
    this.educationForm = null;
    this.orderNumber = null;
    this.subject = null;
    this.dsd = null;
    this.course = null;
    this.countStudent = null;
    this.groupCode = null;
    this.plannedLectures = null;
    this.doneLectures = null;
    this.plannedPract = null;
    this.donePract = null;
    this.plannedLaboratory = null;
    this.doneLaboratory = null;
    this.plannedSeminar = null;
    this.doneSeminar = null;
    this.plannedIndividual = null;
    this.doneIndividual = null;
    this.plannedConsultation = null;
    this.doneConsultation = null;
    this.plannedExamConsultation = null;
    this.doneExamConsultation = null;
    this.plannedCheckControl = null;
    this.doneCheckControl = null;
    this.plannedCheckLectureControl = null;
    this.doneCheckLectureControl = null;
    this.plannedEAT = null;
    this.doneEAT = null;
    this.plannedCGS = null;
    this.doneCGS = null;
    this.plannedCoursework = null;
    this.doneCoursework = null;
    this.plannedOffsetting = null;
    this.doneOffsetting = null;
    this.plannedSemestrExam = null;
    this.doneSemestrExam = null;
    this.plannedTrainingPract = null;
    this.doneTrainingPract = null;
    this.plannedStateExam = null;
    this.doneStateExam = null;
    this.plannedDiploma = null;
    this.doneDiploma = null;
    this.plannedPostgraduates = null;
    this.donePostgraduates = null;
    this.plannedDEK = null;
    this.doneDEK = null;
    this.applicationUserId = null;
  }
}
