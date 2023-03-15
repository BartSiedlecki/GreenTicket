import { observer } from 'mobx-react-lite';
import React from 'react';
import { Badge, Col, ListGroup, Row } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { SelectedSeatDto } from '../../app/models/selectedSeatDto';
import { useStore } from '../../app/store/store';

export default observer(function SummaryPanel() {
    const { t } = useTranslation();
    const { eventPageStore: { selectedTickets } } = useStore();

    const getLi = (index: number, ticket: SelectedSeatDto) => {
        return ticket.isStanding ?
            <ListGroup.Item key={index} as="li" className="d-flex justify-content-between align-items-start" >
                <div className="ms-2 me-auto">
                    {index + 1}. {t("Section")} {ticket.sectionName} ({t("standing")})
                </div>
                <span>
                    {ticket.price}zł
                </span>

            </ListGroup.Item>
            :
            <ListGroup.Item key={index} as="li" className="d-flex justify-content-between align-items-start" >
                <div className="ms-2 me-auto">
                    {index + 1}. {t("Section")} {ticket.sectionName}, {t("row")} {ticket.rowName}, {t("seat")} {ticket.seatNo} ({t("seating")})
                </div>
                <span>
                    {ticket.price}zł
                </span>
            </ListGroup.Item>
    }


    const ticketPricesSum = selectedTickets.reduce((acc, o) => acc + o.price, 0);
    const serviceCost = ticketPricesSum * 0.03;
    const totalcost = ticketPricesSum + serviceCost


    return (
        <Row className="border rounded shadow my-4">
            <Col xs={12} className="p-3 text-left">
                <p className="h3 ps-2 mb-0 fw-bold">{t("Summary")}:</p>
            </Col>
            <Col xs={12} className="px-3 text-left">
                <ListGroup variant="flush">{t("ReservedTickets")}
                    {selectedTickets.map((ticket, index) => (
                        getLi(index, ticket)
                    ))}
                    <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start py-1" style={{ border: "none" }} >
                        <div className="ms-2 me-auto"></div>
                        <span>
                            {t("ticketsValue")}: {ticketPricesSum.toFixed(2)}zł
                        </span>
                    </ListGroup.Item>
                    <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start py-1" style={{ border: "none" }} >
                        <div className="ms-2 me-auto"></div>
                        <span>
                            {t("serviceCharge")}: {serviceCost.toFixed(2)}zł
                        </span>
                    </ListGroup.Item>
                    <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start py-1" style={{ border: "none" }} >
                        <div className="ms-2 me-auto"></div>
                        <span>
                            {t("shipment")}: 0zł
                        </span>

                    </ListGroup.Item>
                    <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start py-1" style={{border: "none"}} >
                        <div className="ms-2 me-auto">

                        </div>
                        <span className="h4 fw-bold mb-0">
                            {t("OrderValue")}: {totalcost.toFixed(2)}zł
                        </span>

                    </ListGroup.Item>
                    <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start border-light pt-0 pb-3" style={{ border: "none" }} >
                        <div className="ms-2 me-auto">

                        </div>
                        <span style={{fontSize: "0.8em"}}>
                            ({t("includingTax")})
                        </span>

                    </ListGroup.Item>
                </ListGroup>
            </Col>
        </Row>
    )
})