import React from 'react';
import { Button, Col, Row } from 'react-bootstrap';
import agent from '../../app/API/agent';
import { EventFilterPageDto } from '../../app/models/eventFilterPageDto';
import Image from 'react-bootstrap/Image'
import moment from 'moment';
import { Calendar3, GeoAltFill, InfoCircle, InfoSquare, TicketFill } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { useStore } from '../../app/store/store';

interface Props {
    event: EventFilterPageDto
}

export default function FilteredEventTile({ event }:Props) {
    const { t } = useTranslation();
    const { eventPageStore } = useStore();
    const { loadEvent, checkSessionId } = eventPageStore;

    const handleBuyTicketsButtonClick = () => {
        checkSessionId();
        loadEvent(Number(event.id), true);
    }

    return (
        <>
            <Row className="border rounded shadow my-4" >
                <Col xs={12} md={6} xl={4} xxl={2} className="p-3 text-center text-md-start">
                    <Image fluid rounded src={agent.ImagePath(event.eventCardImage)} alt={`${event.name} logo`} />
                </Col>
                <Col xs={12} md={6} xl={8} xxl={6} className="p-3 text-left">
                    <h4>{event.name}</h4>
                    <p className="h5"><Calendar3 className="mb-1 me-2" />{moment(new Date(event.startDateTime)).format("DD.MM.YYYY HH:mm")} - {moment(new Date(event.endDateTime)).format("HH:mm")}</p>
                    <p className="h5"><GeoAltFill className="mb-1 me-2" />{event.city}, {event.venueName}</p>
                    <p className="h5"><TicketFill className="mb-1 me-2" /> {t("From")} {Math.round(event.priceFrom)} zł</p>
                    <Button size="sm" onClick={() => handleBuyTicketsButtonClick()} variant="primary">{t("BuyTickets")}</Button>
                </Col>
                <Col className="px-4 pt-3 pb-4 text-left d-xl-4" style={{ color: "grey", textAlign: "justify" }}>
                    <h6><InfoSquare className="mb-1 me-1" /> {t(event.description)}</h6>
                </Col>
            </Row>
        </>
    )
}