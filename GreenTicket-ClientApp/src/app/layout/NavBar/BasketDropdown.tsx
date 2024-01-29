import { observer } from 'mobx-react-lite';
import React, { useState } from 'react';
import { Col, Container, ListGroup, NavDropdown, Row } from 'react-bootstrap';
import { BoxArrowRight, Cart4, InfoCircle } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { NavLink } from 'react-router-dom';
import BasketTicketPreviewListItem from '../../../features/BasketDropDown/BasketTicketPreviewListItem';
import { useStore } from '../../store/store';

interface Props {
    className: string
}

export default observer(function BasketDropdown({ className }: Props) {
    const { t } = useTranslation();
    const { basketStore } = useStore();
    const { tickets: ticketsInBasket, removeTicketFromBasket, isBasketEmpty } = basketStore;
    //const [tmpTtate, settmpTtate] = useState(1)

    let distinctEvents = ticketsInBasket.map(ticket => ticket.ticketEvent.name).filter((value, index, self) => self.indexOf(value) === index);
    const basketIsNotEmpty = ticketsInBasket.length > 0;

    const hadleRemoveFromBasket = (placeId: string) => {
        removeTicketFromBasket(placeId);

    //    settmpTtate(tmpTtate + 1)
    }



    return (
        <>
            <NavDropdown
                id="user-nav-dropdown"
                autoClose="outside"
                className={className}
                title={
                    <>
                        <span className={isBasketEmpty() ? undefined : "basket-blinking"} >
                            <Cart4
                                height={26}
                                width={26}
                            />
                        </span>
                    </>
                }
            >
                <Container className="dropdown-menu-lg-start px-0" style={{ minWidth: "400px" }}>
                    <Row>
                        <Col xs={12}>
                            {basketIsNotEmpty ?
                                <>
                                    <h5 className="mb-1 text-center fw-bold text-success">{t("ReservedTickets")}</h5>
                                    <ListGroup variant="flush">
                                        {distinctEvents.map((eventName, index) => (
                                            <ListGroup.Item key={index} as="li" className="justify-content-between align-items-start" >
                                                <div className="me-auto">
                                                    <b>{eventName}:</b>
                                                </div>
                                                {ticketsInBasket.filter(ticket => ticket.ticketEvent.name === eventName).map((ticket, ticketIndex) => (
                                                    <BasketTicketPreviewListItem key={ticketIndex} index={ticketIndex} ticket={ticket} onRemove={hadleRemoveFromBasket} />
                                                ))}
                                            </ListGroup.Item>
                                        ))}
                                    </ListGroup>
                                </>
                                :
                                <div className="py-3 text-center fw-bold">
                                    <InfoCircle className="ms-2 mb-1" />
                                    <span className="ms-2 text-center">{t("EmptyBasket")}</span>
                                </div>
                            }
                        </Col>
                    </Row>
                    {basketIsNotEmpty ?
                        <>
                            <NavDropdown.Divider />
                            <NavDropdown.Item
                                className="text-center fw-bold"
                                as={NavLink}
                                to={`/basket`}>
                                {t("GoToSummary")}
                                <BoxArrowRight className="ms-2" width={20} height={20} />
                            </NavDropdown.Item>
                        </>
                        : null
                    }
                </Container>
            </NavDropdown>
        </>
    )
})