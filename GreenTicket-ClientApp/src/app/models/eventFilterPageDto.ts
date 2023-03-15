
export interface EventFilterPageDto {
    id: number;
    name: string;
    startDateTime: Date;
    endDateTime: Date;
    description: string;
    city: string;
    venueName: string;
    eventCardImage: string;
    priceFrom: number;
    limitPerUser: number;
}