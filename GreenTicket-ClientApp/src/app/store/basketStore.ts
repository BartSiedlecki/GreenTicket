import { makeAutoObservable } from "mobx";
import { BasketTicket } from "../models/basketTicket";
import { EventPageDto } from "../models/eventPageDto";
import { RowDto } from "../models/rowDto";
import { SeatDto } from "../models/seatDto";
import { SectionDto } from "../models/sectionDto";

export default class BasketStore {
    constructor() {
        makeAutoObservable(this)
    }

    tickets: BasketTicket[] = [];
    setTickets = (val: BasketTicket[]) => this.tickets = val;

    reservedEvents: EventPageDto[] = []
    setReservedEvents = (events: EventPageDto[]) => this.reservedEvents = events;

    sumOfTicketPrices: number = 0;
    setSumOfTicketPrices = (val: number) => this.sumOfTicketPrices = val;
    
    isBasketEmpty = () => this.tickets.length === 0;

    isSeatInCurrentReservation = (seadTicket: SeatDto) => this.tickets.some(x => x.placeId === seadTicket.id)

    canAddSeatTicket = (seadTicket: SeatDto) => !(seadTicket.sold || seadTicket.reserved || this.tickets.some(x => x.placeId === seadTicket.id));

    ticketLimitReached = (event: EventPageDto) => {
        const limitPerUser = event.limitPerUser;
        const selectedTicketsCount = this.tickets.filter(x => x.ticketEvent.id === event.id).length;

        return (selectedTicketsCount < limitPerUser)
    } 

    addSeatingTicketToBasket = (event: EventPageDto, section: SectionDto, row: RowDto, newSeat: SeatDto, reservedTo: Date) => {
        const newTicket: BasketTicket = {
            placeId: newSeat.id,
            isStanding: false,
            rowName: row.name,
            seatNo: newSeat.number,
            price: section.price,
            sectionId: section.id,
            sectionName: section.name,
            reservedTo: reservedTo,
            ticketEvent: event
        }

        const newTicketsArray = [...this.tickets, newTicket].sort((a, b) => a.ticketEvent.name < b.ticketEvent.name ? -1 : 1)
            .sort((a, b) => a.sectionName < b.sectionName ? -1 : 1)
            .sort((a, b) => a.isStanding === b.isStanding ? -1 : 1)
            .sort((a, b) => a.reservedTo < b.reservedTo ? -1 : 1);

        this.setTickets(newTicketsArray);

        const sumOfticketsPrices = newTicketsArray.reduce((a, o) => a + o.price, 0);
        this.setSumOfTicketPrices(sumOfticketsPrices);

        let reservedEvents = this.distinctEvents();
        this.setReservedEvents(reservedEvents);
    }

    addStandingTicketToBasket = (event: EventPageDto, section: SectionDto, newSeat: SeatDto, reservedTo: Date) => {
        const newTicket: BasketTicket = {
            placeId: newSeat.id,
            isStanding: true,
            rowName: undefined,
            seatNo: newSeat.number,
            price: section.price,
            sectionId: section.id,
            sectionName: section.name,
            reservedTo: reservedTo,
            ticketEvent: event
        }

        const newTicketsArray = [...this.tickets, newTicket].sort((a, b) => a.ticketEvent.name < b.ticketEvent.name ? -1 : 1)
            .sort((a, b) => a.sectionName < b.sectionName ? -1 : 1)
            .sort((a, b) => a.isStanding === b.isStanding ? -1 : 1)
            .sort((a, b) => a.reservedTo < b.reservedTo ? -1 : 1);

        this.setTickets(newTicketsArray);

        const sumOfticketsPrices = newTicketsArray.reduce((a, o) => a + o.price, 0);
        this.setSumOfTicketPrices(sumOfticketsPrices);

        let reservedEvents = this.distinctEvents();
        this.setReservedEvents(reservedEvents);
    }

    removeTicketFromBasket = (placeId: string) => {
        const newTicketsArray = this.tickets.filter(t => t.placeId !== placeId);
        this.setTickets(newTicketsArray);

        const sumOfticketsPrices = newTicketsArray.reduce((a, o) => a + o.price, 0);
        this.setSumOfTicketPrices(sumOfticketsPrices);

        let reservedEvents = this.distinctEvents();
        this.setReservedEvents(reservedEvents);
    }

    clearBasket = () => {
        this.setTickets([]);
        this.setSumOfTicketPrices(0);
        this.setReservedEvents([]);
    }

    distinctEvents = () => {
        const distinctEventIDs = [...new Set(this.tickets.map(x => x.ticketEvent.id))];
        let events: EventPageDto[] = [];

        this.tickets.forEach(ticket => {
            if (!events.some(e => e.id === ticket.ticketEvent.id && distinctEventIDs.includes(e.id))) {
                events.push(ticket.ticketEvent);
            }
        });

        return events;
    }
}