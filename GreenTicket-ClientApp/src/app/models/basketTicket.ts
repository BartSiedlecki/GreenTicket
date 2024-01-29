import { EventPageDto } from "./eventPageDto";

export interface BasketTicket {
    placeId: string;
    isStanding: boolean;
    price: number;
    sectionId: number;
    sectionName: string;
    rowName: string | undefined;
    seatNo: number | undefined;
    reservedTo: Date;
    ticketEvent: EventPageDto
}   