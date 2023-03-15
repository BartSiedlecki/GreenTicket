import { observer } from 'mobx-react-lite';
import React from 'react';
import { Col } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { toast } from 'react-toastify';
import agent from '../../app/API/agent';
import { RowDto } from '../../app/models/rowDto';
import { SeatDto } from '../../app/models/seatDto';
import { useStore } from '../../app/store/store';

interface Props {
    eventId: number,
    sectionId: number,
    sectionPrice: number,
    row: RowDto
    seat: SeatDto
}

export default observer(function Seat({ eventId, sectionId, sectionPrice, row, seat }: Props) {
    const { t } = useTranslation();
    const { eventPageStore } = useStore();
    const { setSelectedSection, sessionId, loadSectionPreview, canAddNewTicket, event, addSeatingTicket  } = eventPageStore;

    const isSeatAvailable = !(seat.sold || seat.reserved);
    const getCssClass = () => {
        let baseClass = "seating-preview-seat m-1 py-1 rounded"

        if (seat.sold) {
            baseClass += " seating-preview-sold-seat"
        } else if (seat.currentReservation) {
            baseClass += " seating-preview-current-reservation-seat"
        } else if (seat.reserved) {
            baseClass += " seating-preview-reserved-seat"
        }  else {
            baseClass += " seating-preview-available-seat"
        }

        return baseClass;
    }

    const handleSelectSeat = () => {

        if (isSeatAvailable) {

            //console.log("selectedSeatingTickets:");
            //console.log(selectedSeatingTickets);

            //console.log("selectedStandingTicketIds.length");
            //console.log(selectedStandingTicketIds.length);
            //console.log("selectedSeatingTickets.length");
            //console.log(selectedSeatingTickets.length);
            console.log("event?.limitPerUser");
            console.log(event?.limitPerUser);
            console.log("canAddNewTicket");
            console.log(canAddNewTicket);

            if (canAddNewTicket()) {

                agent.Seats.reserve(eventId, sectionId, seat.seatId, sessionId)
                    .catch(error => toast.error(error))
                    .finally(() => agent.Sections.getPreview(eventId, sectionId, sessionId)
                        .then(response => setSelectedSection(response)))

                addSeatingTicket(row.name, sectionPrice, seat);

            } else {
                toast.error(t("LimitReached"))
            }
        } else if (seat.currentReservation) {
            agent.Seats.cancelReservationSeat(eventId, sectionId, seat.seatId, sessionId)
                .catch(error => toast.error(error))
                .finally(() => agent.Sections.getPreview(eventId, sectionId, sessionId)
                    .then(response => setSelectedSection(response)))
        }

    //    loadPreview();
    }

    return (
        <Col
            className={getCssClass()}
            onClick={() => handleSelectSeat()}
            style={{cursor: 'pointer'}}
        >
            {seat.number}
        </Col>
    )
})