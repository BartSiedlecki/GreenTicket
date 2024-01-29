import { observer } from "mobx-react-lite";
import { Button, ListGroup } from "react-bootstrap";
import { Download } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";
import agent from "../../app/API/agent";
import { downloadFile } from "../../app/API/downloadFile";
import { TicketDto } from "../../app/models/ticketDto";
import { useStore } from "../../app/store/store";

interface Props {
    orderId: string,
    tickets: TicketDto[]
}

export default observer(function TicketList({ orderId, tickets }: Props) {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { user } = userStore;


    const handleDownloadTicket = (ticketId: string) => {
        if (user) {
            agent.Tickets.getSingleTicket(user.id, orderId, ticketId)
                .then((response) => downloadFile(response, `ticket.pdf`));
        }
    }

    return (
        <ListGroup as="ol" numbered>
            {tickets.map(ticket => (
                <ListGroup.Item
                    key={ticket.id}
                    as="li"
                    className="d-flex justify-content-between align-items-start"
                >
                    <div className="ms-2 me-auto">
                        {ticket.isStanding ?
                            <div className="fw-bold">{ticket.sectionName}</div>
                            :
                            <div className="fw-bold">{`${t("Section")} ${ticket.sectionName}, ${t("row")} ${ticket.rowName}, ${t("seat")} ${ticket.seatNo}`}</div>
                        }
                        {ticket.isStanding ?
                            <span>{t("standing")}</span>
                            :
                            <span>{t("seating")}</span>
                        }
                    </div>
                    <Button
                        className="mt-2"
                        variant="outline-success"
                        onClick={() => handleDownloadTicket(ticket.id)}
                    >
                        <Download className="me-2" />{t("DownloadTicket")}
                    </Button>

                </ListGroup.Item>
            ))}
        </ListGroup>
    )
})