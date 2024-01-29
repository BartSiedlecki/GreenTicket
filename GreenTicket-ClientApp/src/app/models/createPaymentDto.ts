export interface CreatePaymentDto {
    orderId: string
    amount: number
    paymentMethod: number
    userRecognitionDetail: string
}
