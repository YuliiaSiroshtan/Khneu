export class Publication {
  publicationId: string;
  name: string;
  filePath: string;
  pages: number;
  output: string;
  createdAt: Date;
  publishedAt: Date;
  isPublished: number;
  isOverseas: string;
  ownerId: string;
  citationNumberNMBD: number;
  impactFactorNMBD: number;
  collaboratorsName: string;

  constructor() {
    this.publicationId = null;
    this.name = null;
    this.filePath = null;
    this.pages = null;
    this.output = null;
    this.createdAt = null;
    this.publishedAt = null;
    this.isPublished = null;
    this.isOverseas = null;
    this.ownerId = null;
    this.citationNumberNMBD = null;
    this.impactFactorNMBD = null;
  }
}
