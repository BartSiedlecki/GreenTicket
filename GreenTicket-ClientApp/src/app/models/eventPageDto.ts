import { SectionDto } from "./sectionDto";

export interface EventPageDto {
    id: number;
    name: string;
    startDateTime: Date;
    endDateTime: Date;
    description: string;
    city: string;
    venueName: string;
    eventCardImage: string;
    seatingPlanImage: string;
    priceFrom: number;
    limitPerUser: number;
    sections: SectionDto[];

}