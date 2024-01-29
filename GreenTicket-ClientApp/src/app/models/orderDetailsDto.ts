import { TicketDto } from "./ticketDto"

export interface OrderDetailsDto {
    id: string
    orderNo: string
    orderDate: Date
    totalPrice: number
    tickets: TicketDto[]
}