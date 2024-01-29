import moment from "moment";
import { useState } from "react";
import { Col, Form, Row, Image } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { toast } from "react-toastify";
import customHistory from "../..";
import agent from "../../app/API/agent";
import { CreatePaymentDto } from "../../app/models/createPaymentDto";
import { PaymentOrderDto } from "../../app/models/paymentOrderDto";
import { useStore } from "../../app/store/store";
import blikImg from "../../data/img/blik_logo.webp";
import cardImg from "../../data/img/visa_mastercard_logo.png";
import BlikPaymentForm from "./BlikPaymentForm";
import CardPaymentForm from "./CardPaymentForm";

interface Props {
    order: PaymentOrderDto
}

interface PaymentMethod {
    id: string,
    name: string,
    img: string
}

export default function PaymentForm({ order }: Props) {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { user } = userStore;

    const paymentMethods: PaymentMethod[] = [
        { id: "1", name: "Blik", img: blikImg },
        { id: "2", name: t("Card"), img: cardImg },
    ]

    const [paymentMethod, setPaymentMethod] = useState<PaymentMethod>(paymentMethods[0])

    const handlePaymentMethodChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const selectedId = event.target.value;
        if (paymentMethods.some(pm => pm.id === selectedId)) {
            setPaymentMethod(paymentMethods.find(method => method.id === selectedId)!)
        }
    }

    const makePayment = (userRecognitionDetail: string | undefined) => {
        const paymentDto: CreatePaymentDto = {
            orderId: order.id,
            amount: order.totalPrice,
            paymentMethod: 1,
            userRecognitionDetail: paymentMethod.id === "Blik" ? "Blik" : "7890"
        }

        if (user) {
            agent.Orders.makePayment(user.id, paymentDto)
                .then(() => {
                    toast.success(t("PaymentSuccess"))
                    customHistory.push(`/orders/${order.id}`)
                })
                .catch(() => {
                    toast.error(t("PaymentFailedInfo"))
                });

        }
    }

    return <>
        <Row className="border rounded shadow my-4 px-4 pt-5 align-top" style={{ minHeight: "830px" }}>
            <Col xs={12}>
                <Row>
                    <Col xs={12} className="p-3 pb-auto text-center">
                        <p className="h4 mb-0 fw-bold">{t("OrderPayment")}: {order.orderNo}</p>
                    </Col>
                </Row>
                <Row>
                    <Col xs={12} md={6} className="p-5 text-left">
                        <Row>
                            <Col xs={12} className="p-3 pb-0">
                                <p className="h5 mb-0"><span className="fw-bold">{t("FullName")}:</span> {order.userFirstName} {order.userLastName}</p>
                            </Col>
                            <Col xs={12} className="p-3 pb-0">
                                <p className="h5 mb-0"><span className="fw-bold">{t("TotalAmount")}:</span> {order.totalPrice}zł</p>
                            </Col>
                            <Col xs={12} className="p-3 pb-0">
                                <p className="h5 mb-0"><span className="fw-bold">{t("OrderNo")}:</span> {order.orderNo}</p>
                            </Col>
                            <Col xs={12} className="p-3 pb-0">
                                <p className="h5 mb-0"><span className="fw-bold">{t("OrderDate")}:</span> {moment(new Date(order.orderDate)).format("DD.MM.YYYY HH:mm")}</p>
                            </Col>
                        </Row>
                        <Row>
                            <div className="mx-auto" style={{ maxWidth: "400px" }}>

                            </div>
                        </Row>
                    </Col>
                    <Col xs={12} md={6} className="p-5 text-center">
                        <Col xs={8} className="mx-auto text-center" >
                            <Form>
                                <Form.Group className="mb-3">
                                    <Form.Label className="fw-bold fs103em">{t("PaymentMethod")}:</Form.Label>
                                    <Form.Select size="lg" value={paymentMethod.id} onChange={handlePaymentMethodChange}>
                                        {paymentMethods.map((method, index) => (
                                            <option key={index} value={method.id}>{method.name}</option>
                                        ))}
                                    </Form.Select>
                                </Form.Group>
                            </Form>
                        </Col>
                        <Col xs={12} className="text-center" >
                            <Image height={100} src={paymentMethod.img} alt={paymentMethod.name} />
                        </Col>
                        {paymentMethod.id === "1" ?
                            <>
                                <Col xs={12} className="p-5 mt-5s text-center" >
                                    <div className="mx-auto" style={{ maxWidth: "400px" }}>
                                        <BlikPaymentForm makePayment={makePayment} />
                                    </div>
                                </Col>
                                <Col className="mt-5">
                                </Col>
                            </>
                            : undefined}
                        {paymentMethod.id === "2" ?
                            <Col xs={12} className=" mt-4 text-center h-100" >
                                <div className="mx-auto" style={{ maxWidth: "400px" }}>
                                    <CardPaymentForm makePayment={makePayment} />
                                </div>
                            </Col>
                            : undefined}
                    </Col>
                </Row>
            </Col>
        </Row>
    </>
}