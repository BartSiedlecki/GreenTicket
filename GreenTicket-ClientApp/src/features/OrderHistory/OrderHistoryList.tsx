/* eslint-disable react/jsx-no-undef */
/* eslint-disable no-restricted-globals */
import moment from "moment";
import { useEffect, useState } from "react";
import { Button, Card, Col, ListGroup, Row } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import agent from "../../app/API/agent";
import { OrderListItemDto } from "../../app/models/orderListItemDto";
import { useStore } from "../../app/store/store";
import customHistory from "../..";
import { downloadFile } from "../../app/API/downloadFile";


export default function OrderListoryList() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { user } = userStore;
    const [orderList, setOrderList] = useState<OrderListItemDto[]>([]);

    useEffect(() => {
        if (user) {
            agent.Orders.getList(user.id)
                .then(response => {
                    setOrderList(response)
                })
        }
    }, []);

    const handleOrderDetailsButtonClick = (orderId: string) => {
        customHistory.push(`/orders/${orderId}`);
    }

    const handleGetORderTicketsButtonClick = (orderId: string, orderNo: string) => {
        if (user) {
            agent.Tickets.getOrderTickets(user.id, orderId)
                .then((response) => downloadFile(response, `tickets_${orderNo}.pdf`))
        }
    }

    const habdlePayOrderButtonClick = (orderId: string) => {
        customHistory.push(`/payment/${orderId}`);
    }

    return <>
        <Row className="border rounded shadow my-4 p-2">
            <Col xs={12} className="p-3 text-left">
                {orderList.map(order => (<>
                    <Row key={order.id}>
                        <Col xs={12} className="my-3">
                            <Card>
                                <Card.Header as="h5">
                                    <Row className="fw-bold">
                                        <Col xs={6}>{`${t("OrderNo")}: ${order.orderNo}`}</Col>
                                        <Col xs={6} className={`text-end ${order.alreadyPaid ? "text-success" : "text-danger"}`}>
                                            {order.alreadyPaid ? t("Paid") : t("NotPaid")}
                                        </Col>
                                    </Row>
                                </Card.Header>
                                <Card.Body className="fs101em">
                                    <Card.Text>
                                        <Row>
                                            <Col xs={12}>
                                                <span className="fw-bold">{t("OrderDate")}: {moment(new Date(order.orderDate)).format("DD.MM.YYYY HH:mm")}</span>
                                            </Col>

                                            <Col xs={12} className="mt-3 h5">
                                                <ListGroup variant="flush">
                                                    {order.events ?
                                                        order.events.map((ev, index) => (
                                                            <ListGroup.Item key={index}>
                                                                <Row>
                                                                    <Col xs={12} className="fw-bold">
                                                                        {ev.name}
                                                                    </Col>
                                                                    <Col xs={12}>
                                                                        {ev.city}, {moment(new Date(ev.startDateTime)).format("DD.MM.YYYY HH:mm")}
                                                                    </Col>
                                                                </Row>
                                                            </ListGroup.Item>
                                                        ))
                                                        : undefined
                                                    }
                                                </ListGroup>
                                            </Col>

                                        </Row>
                                    </Card.Text>

                                    <Row>
                                        <Col xs={12} className="text-end">
                                            {order.alreadyPaid ?
                                                <>
                                                    <Button variant="secondary" className="m-1" onClick={() => handleOrderDetailsButtonClick(order.id)}>{t("OrderDetails")}</Button>
                                                    <Button variant="success" className="m-1" onClick={() => handleGetORderTicketsButtonClick(order.id, order.orderNo)}>{t("DownloadTickets")}</Button>
                                                </>
                                                :
                                                <Button variant="primary" className="m-1" onClick={() => habdlePayOrderButtonClick(order.id)}>{t("PayOrder")}</Button>
                                            }
                                        </Col>
                                    </Row>
                                </Card.Body>
                            </Card>
                        </Col>
                    </Row>
                </>))}
            </Col>
        </Row>
    </>
}