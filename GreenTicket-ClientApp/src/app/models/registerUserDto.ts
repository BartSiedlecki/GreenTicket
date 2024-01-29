export interface RegisterUserDto {
    firstName: string,
    lastName: string,
    dateOfBirth: Date | null,
    email: string,
    password: string,
    repeatPassword: string,
    street: string,
    streetNo: string,
    postalCode: string,
    city: string,
    countryId: string
}