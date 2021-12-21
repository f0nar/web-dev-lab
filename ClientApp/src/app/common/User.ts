export interface UserJson {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    passwordConfirmed: true;
    headId: string;
    head: string;
    subUsers: string[];
}

export interface IUser {
    getFirstName(): string;
    getLastName(): string;
}