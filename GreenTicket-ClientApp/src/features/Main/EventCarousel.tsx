import moment from 'moment';
import React, { useEffect, useState } from 'react';
import { Carousel } from 'react-bootstrap';
import agent from '../../app/API/agent';
import { EventCarouselDto } from '../../app/models/eventCarouselDto';

export function EventCarousel() {

    const [carouselEvents, setCarouselEvents] = useState<EventCarouselDto[]>([]);

    useEffect(() => {
        agent.Events.carousels(3)
            .then(response => setCarouselEvents(response));
    }, [])
    
    return (
        <Carousel fade>
            {carouselEvents.map((model, index) => {
                return (
                <Carousel.Item key={index}>
                        <img
                            className="d-block w-100"
                            src={agent.ImagePath(model.imageFileName)}
                            alt={model.name}
                    />
                    <Carousel.Caption>
                        <h3>{model.name}</h3>
                            <p>{`${model.city}, ${moment(new Date(model.startDateTime)).format("DD.MM.YYYY") }`}</p>
                    </Carousel.Caption>
                </Carousel.Item>)
            })}
        </Carousel>
    )
}



