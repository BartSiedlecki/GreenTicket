import { EventSubCategoryNavDto } from "./eventSubCategoryNavDto";

export interface EventCategoryNavDto {
    id: number;
    title: string;
    subCategories: EventSubCategoryNavDto[];
}
