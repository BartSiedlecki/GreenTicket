import { observer } from 'mobx-react-lite';
import moment from 'moment';
import React, { useEffect, useRef } from 'react';
import { Accordion, Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Calendar3, GeoAltFill, InfoCircle, UmbrellaFill } from 'react-bootstrap-icons';
import { useParams } from 'react-router-dom';
import { useStore } from '../../app/store/store';
import { isNumeric } from '../Shared/helpers';
import Image from 'react-bootstrap/Image'
import agent from '../../app/API/agent';
import SeatingSectionsModule from './SeatingSectionsModule';
import StandingSectionsModule from './StandingSectionsModule';
import SummaryPanel from './SummaryPanel';
import { useTranslation } from 'react-i18next';
import { getNewGuid } from '../Shared/GUID';

export default observer(function EventPage() {
    const { t } = useTranslation();
    const { eventId } = useParams<{ eventId: string }>();
    const { eventPageStore } = useStore();
    const { loadingEvent, event, loadEvent, checkSessionId } = eventPageStore;

    const isInitialMount = useRef(true);

    useEffect(() => {
        if (!(event?.id)) {
            if (isNumeric(eventId)) {
                checkSessionId();
                loadEvent(Number(eventId), false);
            }
        }
    }, [eventId]);


    const standingSections = event?.sections.filter(s => s.isStanding === true);
    const seatingSections = event?.sections.filter(s => s.isStanding === false);

    return (
        <>
            <Container className="p-5" fluid >
                {event === null ?
                    ""
                    :
                    <>
                        <Row>
                            <Col xs={12} md={8} >
                                <Row>
                                    <Col xs={12} >
                                        <p className="h1 fw-bold">{event.name}</p>
                                        <p className="h2"><Calendar3 className="mb-1 me-2" />{moment(new Date(event.startDateTime)).format("DD.MM.YYYY HH:mm")}</p>
                                        <p className="h2"><GeoAltFill className="mb-1 me-2" />{event.city}, {event.venueName}</p>
                                        <p className="h5">{t(event?.description)}</p>
                                    </Col>
                                </Row>
                            </Col>
                            <Col xs={12} md={4} className="text-center text-md-end" >
                                <Image fluid rounded src={agent.ImagePath(event.eventCardImage)} alt={`${event.name} logo`} />
                            </Col>
                        </Row>
                        <Row className="border rounded shadow my-4">
                            <Col xs={12} className="p-3 text-center">
                                <p className="h4"><InfoCircle className="mb-1 me-2" />{t("AdditionalCostsInfo")}</p>
                                <p className="h5">{t("DisabilitiesInfo1")}<span className="text-link">{t("DisabilitiesInfo2")}</span>.</p>
                            </Col>
                        </Row>
                        <Row className="border rounded shadow my-4">
                            <Col xs={12} className="p-3 text-center">
                                <p className="h4"><InfoCircle className="mb-1 me-2" />{t("LimitInfo1")} {event.limitPerUser}.</p>
                                <p className="h5">{t("LimitInfo2")} <span className="text-link">{t("ReadMore")}</span>.</p>
                            </Col>
                        </Row>
                        <Row className="border rounded shadow my-4 p-3 p-xxl-5">
                            <Col xs={12} lg={7}>
                                {standingSections !== undefined && standingSections.length > 0 ?
                                    <StandingSectionsModule sections={standingSections} />
                                    : null}
                                {seatingSections !== undefined && seatingSections.length > 0 ?
                                    <SeatingSectionsModule eventId={Number(eventId)} sections={seatingSections} />
                                    : null}
                            </Col>
                            <Col xs={12} lg={5} className="text-center px-lg-4 d-flex align-items-center justify-content-center">
                                <Image fluid src={agent.ImagePath(event.seatingPlanImage)} alt={`${event.name} seating plan`} />
                            </Col>
                        </Row>
                        <SummaryPanel />
                        <Row>
                            <Col xs={12} className="text-end pe-4">
                                <Button variant="success" size="lg">
                                    Large button
                                </Button>
                            </Col>
                        </Row>
                    </>
                }
            </Container>
        </>
    )
})