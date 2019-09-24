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
