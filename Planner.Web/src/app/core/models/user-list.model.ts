export class UserList {
    applicationUserId: string;
    email: string;
    fullName: string;
    isActive: boolean;

    constructor() {
        this.applicationUserId = null;
        this.email = null;
        this.fullName = null;
        this.isActive = false;
    }
}
