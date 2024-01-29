import { VenueDto } from "./venueDto"

export interface TicketDto {
    id: string
    cancelled: boolean
    price: number
    isStanding: boolean
    sectionName: string
    seatNo: number
    rowName: string
    eventId: number
    eventName: any
    eventStartDate: string
    eventEndDate: string
    venue: VenueDto
}