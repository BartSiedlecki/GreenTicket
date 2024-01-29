import { useEffect, useState } from "react";
import { Col, Row } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { TicketDto } from "../../app/models/ticketDto"
import TicketList from "./TicketList";
import TicketListEventDetails from "./TicketListEventDetails";

interface Props {
    orderId: string,
    tickets: TicketDto[]
}


export default function OrderDetailsTicketsPanel({ orderId, tickets }: Props) {
    const {t } = useTranslation();
    const [discintEventIds, setDiscintEventIds] = useState<number[]>([])

    useEffect(() => {
        setDiscintEventIds([...new Set(tickets.map(item => item.eventId))])
    }, []);

    return (
        <>
            {discintEventIds.map(id => (
                <Row key={id} className="mb-4">
                    <TicketListEventDetails ticket={tickets.filter(item => item.eventId === id)[0]} />
                    <Col xs={12} className="mt-3" >
                        <h5 className="fw-bold">{t("PurchasedTickets")}:</h5>
                    </Col>
                    <Col xs={12}>
                        <TicketList orderId={orderId} tickets={tickets.filter(item => item.eventId === id)} />
                    </Col>
                </Row>
            ))}
        </>
    )
}

