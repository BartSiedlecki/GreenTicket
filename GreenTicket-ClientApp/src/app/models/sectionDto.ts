import { RowDto } from "./rowDto";

export interface SectionDto {
    id: number;
    name: string;
    capacity: number;
    price: number;
    isStanding: boolean;
    rows: RowDto[];
}