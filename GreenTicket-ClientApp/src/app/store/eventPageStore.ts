import { makeAutoObservable, runInAction } from "mobx";
import { getNewGuid } from "../../features/Shared/GUID";
import agent from "../API/agent";
import { EventPageDto } from "../models/eventPageDto";
import { SectionDto } from "../models/sectionDto";
import customHistory from '../..';
import { SeatDto } from "../models/seatDto";
import { SelectedSeatDto } from "../models/selectedSeatDto";
import { prepareRoutingParamText } from "../../features/Shared/helpers";

export default class EventPageStore {
    constructor() {
        makeAutoObservable(this)
    }


    loadingEvent = true;
    setLoadingEvent = (loadingEvent: boolean) => this.loadingEvent = loadingEvent;

    sessionId: string = "";
    setSessionId = (val: string) => this.sessionId = val;

    event: EventPageDto | null = null;
    setEvent = (val: EventPageDto | null) => this.event = val;

    selectedSection: SectionDto | null = null;
    setSelectedSection = (val: SectionDto | null) => this.selectedSection = val;


    ////

    selectedTickets: SelectedSeatDto[] = [];
    setSelectedTickets = (val: SelectedSeatDto[]) => this.selectedTickets = val;

    //selectedStandingTicketIds: number[] = [];
    //setSelectedStandingTicketIds = (val: number[]) => this.selectedStandingTicketIds = val;

    //selectedSeatingTickets: SeatDto[] = [];
    //setSelectedSeatingTickets = (val: SeatDto[]) => this.selectedSeatingTickets = val;

    addSeatingTicket = (rowName: string, sectionPrice: number, newSeat: SeatDto) => {

        //const newList = this.selectedSeatingTickets;
        //newList.push(newSeat)
        //this.setSelectedSeatingTickets(newList);
        const newSelectedTicket: SelectedSeatDto = {
            seatId: newSeat.seatId,
            isStanding: false,
            rowName: rowName,
            seatNo: newSeat.number,
            price: newSeat.customPrice ? newSeat.customPrice : sectionPrice,
            sectionId: this.selectedSection?.id!,
            sectionName: this.selectedSection?.name!
        }

        const newList = this.selectedTickets;
        newList.push(newSelectedTicket);
        this.setSelectedTickets(newList);
    }


    canAddNewTicket = () => {

    //    return (this.selectedStandingTicketIds.length + this.selectedSeatingTickets.length) < this.event?.limitPerUser!;
        return (this.selectedTickets.length) < this.event?.limitPerUser!;
    } 
    ////

    loadEvent = (id: number, redirect: boolean) => {
        this.setSelectedSection(null);
        agent.Events.getEventPageMode(id)
            .then(response => {
                this.setEvent(response);
                this.loadSectionPreview();
            })
            .then(() => this.setLoadingEvent(false))
            .then(() => redirect ? customHistory.push(`/event/${prepareRoutingParamText(this.event?.name)}/${prepareRoutingParamText(this.event?.city)}/${this.event?.id}`) : undefined);
    }

    //totalNoOfSelectedTickets = () => {
    //    return this.selectedStandingTicketIds.length;
    //}

    loadSectionPreview = () => {
        let sectionId: number | undefined = undefined;
        if (this.event) {


            if (this.selectedSection === null) {
                const firstSeatedSection = this.event.sections.find(s => s.isStanding === false)
                if (firstSeatedSection) {
                    sectionId = firstSeatedSection.id;
                }
            } else {
                sectionId = this.selectedSection.id;
            }

            if (sectionId) {
                agent.Sections.getPreview(this.event.id, sectionId, this.sessionId)
                    .then(response => {
                        this.setSelectedSection(response);
                    })
            }
        }

    }

    checkSessionId = () => {
        runInAction(() => {
            if (localStorage.getItem(`session-id`) !== null) {
                const existingSesstionId = localStorage.getItem(`session-id`)!.toString()
                this.setSessionId(existingSesstionId);
            } else {
                const newGuid = getNewGuid();
                this.setSessionId(newGuid);
                localStorage.setItem(`session-id`, newGuid);
            }
        });
    }

}