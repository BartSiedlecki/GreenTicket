import React from 'react';
import { observer } from 'mobx-react-lite';
import { DashSquare, PlusSquare } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { SelectedSeatDto } from '../../app/models/selectedSeatDto';
import { useStore } from '../../app/store/store';

interface Props {
    sectionId: number;
    sectionPrice: number;
    sectionName: string;
}


export default observer(function AddingTicktsModule({ sectionId, sectionPrice, sectionName }: Props) {
    const { t } = useTranslation();
    const { eventPageStore } = useStore();
    const { event, selectedTickets, setSelectedTickets } = eventPageStore;

    const handleChangeSelectedTicketsNo = (action: "delete" | "add", c: number) => {
        if (action === "delete") {
            let newSelectedTickets = selectedTickets.filter(s => s.sectionId !== sectionId);
            let newSelectedTickets2 = selectedTickets.filter(s => s.sectionId === sectionId);
            newSelectedTickets2.shift();

            setSelectedTickets(newSelectedTickets.concat(newSelectedTickets2))
        } else {
            let newSelectedTickets = selectedTickets;

            const newSelectedTicket: SelectedSeatDto = {
                seatId: undefined,
                isStanding: true,
                rowName: undefined,
                seatNo: undefined,
                price: sectionPrice,
                eventName: event!.name!,
                sectionId: sectionId!,
                sectionName: sectionName
            }

            newSelectedTickets.push(newSelectedTicket);

            setSelectedTickets(newSelectedTickets);
        }
    }

    const noOfSelectedTicketsForCurrentSection = selectedTickets.filter(s => s.sectionId === sectionId).length;

    return (
        <>
            <DashSquare
                className={"btn-add-remove-ticket mb-2 " + (noOfSelectedTicketsForCurrentSection > 0 ? " btn-remove-ticket" : undefined)}
                onClick={selectedTickets.length > 0 ? () => handleChangeSelectedTicketsNo("delete", sectionId) : undefined}
            />
            <span className="mx-3 pt-1 ticket-quantity">{noOfSelectedTicketsForCurrentSection}</span>
            <PlusSquare
                className={"btn-add-remove-ticket mb-2 " + (event!.limitPerUser >= selectedTickets.length + 1 ? " btn-add-ticket" : undefined)}
                onClick={event!.limitPerUser >= selectedTickets.length + 1 ? () => handleChangeSelectedTicketsNo("add", sectionId) : undefined}
            />
        </>
    )
})