import React, { useEffect, useState } from 'react';
import { Carousel, Col, Container, Row } from 'react-bootstrap';
import { EventCardDto } from '../../app/models/eventCardDto';
import EventCard from './EventCard';

interface Props {
    categoryName: string,
    events: EventCardDto[],
    icon: any
}

interface CarouselItem {
    index: number,
    events: EventCardDto[]
}

export default function MainCategory({ categoryName, events, icon }: Props) {
    const [index, setIndex] = useState(0);

    const handleSelect = (selectedIndex: any, e: any) => {
        setIndex(selectedIndex);
    };

    const [windowSize, setWindowSize] = useState([
        window.innerWidth,
    ]);
    const [noOfCardsInRow, setNoOfCardsInRow] = useState(6);

    useEffect(() => {
        const handleWindowResize = () => {
            setWindowSize([window.innerWidth]);
        };

        window.addEventListener('resize', handleWindowResize);

        getNoOfCardsInRow(window.innerWidth);

        return () => {
            window.removeEventListener('resize', handleWindowResize);
        };

    });

    const getNoOfCardsInRow = (windowWidth: number) => {
        if (windowWidth < 576) {
            setNoOfCardsInRow(1);
        } else if (windowWidth < 992) {
            setNoOfCardsInRow(2);
        }  else if (windowWidth < 1400) {
            setNoOfCardsInRow(3);
        } else {
            setNoOfCardsInRow(5);
        }
    }

    useEffect(() => {
        setIndex(0);
    }, [noOfCardsInRow])

    const noOfItems = events.length / noOfCardsInRow;

    const cardSetForCurrentScreenResolution: CarouselItem[] = [];

    for (var i = 0; i < noOfItems; i++) {

        const newRow = events.slice(i * noOfCardsInRow, i * noOfCardsInRow + noOfCardsInRow);

        if (newRow.length == noOfCardsInRow) {
            cardSetForCurrentScreenResolution.push({ index: i, events: newRow })
        }
    }

    return (
        <div className="py-4">
            <Row>
                <Col xs={12} className="text-center">
                    <div className="hr-sect mb-0">{icon} {categoryName}</div>
                </Col>
            </Row>
            <Row>
                <Carousel interval={5000} indicators={false} activeIndex={index} onSelect={handleSelect}>
                    {cardSetForCurrentScreenResolution.map(carouselItem => (
                        <Carousel.Item key={carouselItem.index}>
                            <Row className="py-4">
                                <Col xs={1} md={1}>
                                </Col>
                                {carouselItem.events.map((event, index) => (
                                    <Col  key={index} className="mx-auto">
                                        <EventCard event={event} />
                                    </Col>
                                ))}
                                <Col xs={1} md={1}>
                                </Col>
                            </Row>
                        </Carousel.Item>
                    ))}
                </Carousel>
            </Row>
        </div>
    )
}