import { observer } from "mobx-react-lite"
import moment from "moment";
import { CSSProperties } from "react";
import { Col, ListGroup, Row } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { BasketTicket } from "../../app/models/basketTicket";
import { EventPageDto } from "../../app/models/eventPageDto";
import { useStore } from "../../app/store/store"
import { serviceCostRate } from "../../config";


export default observer(function BasketReservationSummary() {
    const { t } = useTranslation();
    const { basketStore } = useStore();
    const { tickets: allReservedTickets, reservedEvents } = basketStore;
    
    const ticketPricesSum = allReservedTickets.reduce((acc, o) => acc + o.price, 0);
    const serviceCost = ticketPricesSum * serviceCostRate;
    const totalcost = ticketPricesSum + serviceCost

    const ListItem = (index: number, ticket: BasketTicket) => {
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
                <div className="m1-2 me-auto">
                    {index + 1}. {ticket.sectionName}, {t("row")} {ticket.rowName}, {t("seat")} {ticket.seatNo} ({t("seating")})
                </div>
                <span>
                    {ticket.price}zł
                </span>
            </ListGroup.Item>
    }

    const SummaryListItem = (text: string, cssProperties: CSSProperties | undefined = undefined) => {
        return <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start py-1" style={{ border: "none" }} >
            <div className="ms-2 me-auto"></div>
            <span style={cssProperties}>{text}</span>
        </ListGroup.Item>
    }

    return (<>
        <Row className="border rounded shadow my-4 p-2">
            <Col xs={12} className="p-3 pb-0 text-left">
                <p className="h2 mb-0 fw-bold">{t("ReservedTickets")}:</p>
            </Col>
            <Col xs={12} className="p-3 text-left">
                {reservedEvents.map(event =>
                    <div className="mb-3" key={event.id}>
                        <p className="h5 ps-1 mb-0 fw-bold">{event.name}, {event.city} { moment(new Date(event.startDateTime)).format("DD.MM.YYYY HH:mm")}</p>
                        <ListGroup variant="flush">
                            {allReservedTickets.filter(t => t.ticketEvent.id === event.id).map((ticket, index) => (
                                ListItem(index, ticket)
                            ))}
                        </ListGroup>
                    </div>
                )}
            </Col>
            <Col xs={12} className="p-3">
                <ListGroup variant="flush">
                    <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start py-1 fw-bold">
                        <div className="ms-2 me-auto"></div>
                        <span>
                            {t("Summary")}:
                        </span>
                    </ListGroup.Item>
                    {SummaryListItem(`${t("ticketsValue")}: ${ticketPricesSum.toFixed(2)}zł`)}
                    {SummaryListItem(`${t("serviceCharge")}: ${serviceCost.toFixed(2)}zł`)}
                    {SummaryListItem(`${t("shipment")}: 0zł`)}
                    {SummaryListItem(`${t("shipment")}: 0zł`)}
                    {SummaryListItem(`${t("OrderValue")}: ${totalcost.toFixed(2)}zł`, {fontSize: "1.3em", fontWeight: "700"})}
                    {SummaryListItem(`(${t("includingTax)")}`, {fontSize: "0.7em"})}
                </ListGroup>
            </Col>
        </Row>
    </>)
})