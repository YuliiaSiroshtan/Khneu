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
