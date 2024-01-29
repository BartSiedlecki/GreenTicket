export interface PaymentOrderDto {

    id: string,
    orderNo: string,
    userFirstName: string,
    userLastName: string,
    orderDate: Date,
    totalPrice: number,
    alreadyPaid: boolean,
}