export interface SeatDto {
    id: string;
    number: number;
    customPrice: number;
    restrictionDescpiption: string;
    sold: boolean;
    currentReservation: boolean;
    reserved: boolean;
}