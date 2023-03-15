import { makeAutoObservable } from "mobx";
import { config } from "../../config";
import agent from "../API/agent";
import { CardCategory } from "../models/cardCategory";
import { EventCardDto } from "../models/eventCardDto";

export default class MainStore {
        constructor() {
            makeAutoObservable(this);
        }

    newestEvents: EventCardDto[] = [];
    setNewestEvents = (val: EventCardDto[]) => this.newestEvents = val;

    sportEvents: EventCardDto[] = [];
    setSportEvents = (val: EventCardDto[]) => this.sportEvents = val;

    cultureEvents: EventCardDto[] = [];
    setCultureEvents = (val: EventCardDto[]) => this.cultureEvents = val;

    concertEvents: EventCardDto[] = [];
    setConcertEvents = (val: EventCardDto[]) => this.cultureEvents = val;

    loadEventCards = (category: CardCategory) => {
        agent.Events.eventCards(category, config.noOfCardsInBlock)
            .then(response => {
                switch (category) {
                    case "Newest":
                        this.setNewestEvents(response);
                        break;
                    case "Sport":
                        this.setSportEvents(response);
                        break;
                    case "Culture":
                        this.setCultureEvents(response);
                        break;
                    case "Concert":
                        this.setConcertEvents(response);
                        break;
                    default:
                }
            });
    }

    loadMainEvents = () => {
        this.loadEventCards("Newest");
        this.loadEventCards("Sport");
        this.loadEventCards("Culture");
        this.loadEventCards("Concert");
    }


}