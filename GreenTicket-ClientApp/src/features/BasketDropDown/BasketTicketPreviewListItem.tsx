import { observer } from 'mobx-react-lite';
import React from 'react';
import { XCircleFill } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { BasketTicket } from '../../app/models/basketTicket';
import CountdownTime from './CountdownTime';

interface Props {
    index: number,
    ticket: BasketTicket,
    onRemove: (placeID: string) => void;
}

export default observer(function BasketTicketPreviewListItem({ index, ticket, onRemove }: Props) {
    const { t } = useTranslation();

    return (
        <div className="d-flex justify-content-between align-items-start py-1">
            <span>{index + 1}. {ticket.sectionName}, {t("row")} {ticket.rowName}, {t("seat")} {ticket.seatNo}, {ticket.price}zł</span>
            <span className="ms-auto fw-bold">
                <CountdownTime reservedTo={ticket.reservedTo} placeId={ticket.placeId} onRemove={onRemove} />
            </span>
            <span className="ms-2 text-danger">
                <XCircleFill className="mb-1" style={{ cursor: "pointer" }} onClick={() => onRemove(ticket.placeId)} />
            </span>
        </div>
    )
})