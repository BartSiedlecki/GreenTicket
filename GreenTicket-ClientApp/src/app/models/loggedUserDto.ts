import { RoleDto } from "./roleDto";

export interface LoggedUserDto {
    id: string;
    firstName: string;
    role: RoleDto;
}