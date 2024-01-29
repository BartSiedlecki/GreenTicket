export interface SelectedSeatDto {
    seatId: string | undefined;
    isStanding: boolean;
    rowName: string | undefined;
    seatNo: number | undefined;
    price: number;
    eventName: string;
    sectionId: number;
    sectionName: string;
}