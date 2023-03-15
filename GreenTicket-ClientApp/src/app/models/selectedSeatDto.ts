export interface SelectedSeatDto {
    seatId: string | undefined;
    isStanding: boolean;
    rowName: string | undefined;
    seatNo: number | undefined;
    price: number;
    sectionId: number;
    sectionName: string;
}