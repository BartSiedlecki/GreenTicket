import moment from "moment";
import { Col } from "react-bootstrap";
import { Calendar3, GeoAltFill } from "react-bootstrap-icons";
import { TicketDto } from "../../app/models/ticketDto";

interface Props {
    ticket: TicketDto
}


export default function TicketListEventDetails({ ticket }: Props) {

    return (
        <Col xs={12} >
            <p className="h4 fw-bold">{ticket.eventName}</p>
            <p className="h5"><Calendar3 className="mb-1 me-2" />{moment(new Date(ticket.eventStartDate)).format("DD.MM.YYYY HH:mm")}</p>
            <p className="h5"><GeoAltFill className="mb-1 me-2" />{ticket.venue.city}, {ticket.venue.name}</p>
        </Col>
    )
}
