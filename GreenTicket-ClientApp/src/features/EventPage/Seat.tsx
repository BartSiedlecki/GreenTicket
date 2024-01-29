import { observer } from 'mobx-react-lite';
import React, { useState } from 'react';
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
    const { eventPageStore, basketStore } = useStore();
    const { setSelectedSection, sessionId, selectedSection, event  } = eventPageStore;
    const { canAddSeatTicket, isSeatInCurrentReservation, addSeatingTicketToBasket, removeTicketFromBasket, ticketLimitReached } = basketStore;

    const isSeatInCurReservation = isSeatInCurrentReservation(seat);
    const isSeatAvailable = canAddSeatTicket(seat);
    const getCssClass = () => {
        let baseClass = "seating-preview-seat m-1 py-1 rounded"


        if (seat.sold) {
            baseClass += " seating-preview-sold-seat"
        } else if (isSeatInCurReservation) {
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
            if (ticketLimitReached(event!)) {
                agent.Seats.reserve(eventId, sectionId, seat.id, sessionId)
                    .then(response => {
                        addSeatingTicketToBasket(event!, selectedSection!, row, seat, response);
                    })
                    .catch(error => toast.error(error))
                    .finally(() => agent.Sections.getPreview(eventId, sectionId, sessionId)
                        .then(response => setSelectedSection(response)))

            } else {
                toast.error(t("LimitReached"))
            }
        } else if (seat.currentReservation) {
            agent.Seats.cancelReservationSeat(eventId, sectionId, seat.id, sessionId)
                .catch(error => toast.error(error))
                .finally(() => agent.Sections.getPreview(eventId, sectionId, sessionId)
                    .then(response => setSelectedSection(response)))

            removeTicketFromBasket(seat.id);
        }
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