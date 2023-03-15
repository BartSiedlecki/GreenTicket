export interface SeatDto {
    seatId: string;
    number: number;
    customPrice: number;
    restrictionDescpiption: string;
    sold: boolean;
    currentReservation: boolean;
    reserved: boolean;
}