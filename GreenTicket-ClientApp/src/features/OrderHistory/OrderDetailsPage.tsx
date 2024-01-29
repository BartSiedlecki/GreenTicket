import moment from "moment";
import { useEffect, useState } from "react";
import { Col, Container, Row } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";
import agent from "../../app/API/agent";
import { OrderDetailsDto } from "../../app/models/orderDetailsDto";
import { useStore } from "../../app/store/store";
import OrderDetailsTicketsPanel from "./OrderDetailsTicketsPanel";

export default function OrderDetailsPage() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { user } = userStore;
    const { orderId } = useParams<{ orderId: string }>();

    const [orderDetails, setOrderDetails] = useState<OrderDetailsDto | undefined>(undefined)

    useEffect(() => {
        if (user && orderId) {
            agent.Orders.getDetails(user.id, orderId).then(response => {
                setOrderDetails(response);
            })
        }
    }, []);

    return (
        <>
            <Container className="p-5" fluid >
                {
                    orderDetails ?
                        <Row className="border rounded shadow my-4 p-2">
                            <Col xs={12} className="p-3 text-left">
                                <Row>
                                    <Col xs={12} className="my-3 text-center fw-bold">
                                        <h2>
                                            {`${t("Order")}: ${orderDetails?.orderNo}`}
                                        </h2>
                                    </Col>
                                </Row>
                                <Row className="fw-bold h4">
                                    <Col xs={6} className="my-3">
                                        {`${t("TotalAmount")}: ${orderDetails.totalPrice}zł`}
                                    </Col>
                                    <Col xs={6} className="my-3 text-end">
                                        {`${t("CreatenOn")}: ${moment(new Date(orderDetails.orderDate)).format("DD.MM.YYYY")}`}
                                    </Col>
                                </Row>
                            </Col>
                            {orderId ?
                                <Col xs={12} className="p-3 text-left">
                                    <OrderDetailsTicketsPanel orderId={orderId} tickets={orderDetails.tickets} />
                                </Col>
                                :
                                undefined
                            }
                        </Row>
                        : undefined
                }
            </Container>
        </>
    )
}