import { EventCarouselDto } from "./eventCarouselDto"

export interface OrderListItemDto {
    id: string
    orderNo: string
    orderDate: string
    totalPrice: number
    alreadyPaid: boolean
    events: EventCarouselDto[]
}