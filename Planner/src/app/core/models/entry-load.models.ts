export class EntryLoadsPropertyViewModel {
  id: string;
  name: string;
  dateTimeUpload: string;
  hoursPerRate: string;
  isActive: string;
}

export class UserEntryLoadsPropertyViewModel {
  id: string;
  name: string;
  userId: number;
  dserName: string;
  dateTimeUpload: string;
}

export class EntryLoadsPropertyDto {
  id: number;
  name: string;
  dateTimeUpload: Date;
  hoursPerRate: number;
  isActive: boolean;
}
