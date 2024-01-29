import { CreateOrderTicketDto } from "./createOrderTicketDto";

export interface OrderCreateDto {
    userId: string;
    tickets: CreateOrderTicketDto[];
}