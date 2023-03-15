import moment from 'moment';
import { Button, Card } from 'react-bootstrap';
import { GeoAltFill, TicketFill, TicketPerforated } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import agent from '../../app/API/agent';
import { EventCardDto } from '../../app/models/eventCardDto';
import { useStore } from '../../app/store/store';

interface Props {
    event: EventCardDto
}

export default function EventCard({ event }: Props) {
    const { t } = useTranslation();
    const { eventPageStore } = useStore();
    const { loadingEvent, loadEvent, checkSessionId } = eventPageStore;


    const handleBuyTicketsButtonClick = () => {
        checkSessionId();
        loadEvent(Number(event.id), true);
    }

    return (
        <>
            <Card className="shadow" >
                <Card.Img variant="top" src={agent.ImagePath(event.imageFileName)} />
                <Card.Body>
                    <Card.Title>{event.name}</Card.Title>
                    <Card.Text className="mb-2">
                        <span>
                            <GeoAltFill className="mb-1 card-bottom-icon" /> {`${event.city}, ${moment(new Date(event.startDateTime)).format("DD.MM.YYYY")}`}
                        </span>
                        <br/>
                        <span>
                            <TicketFill className="mb-1 card-bottom-icon" /> {t("From")} {Math.round(event.priceFrom)} zł
                        </span>
                    </Card.Text>
                    <Button size="sm" onClick={() => handleBuyTicketsButtonClick()} variant="primary">{t("BuyTickets")}</Button>
                </Card.Body>
            </Card>
        </>
    )
}

