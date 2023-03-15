import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import FilterForm from './FilterForm';
import { useStore } from '../../app/store/store';
import FilteredEventTile from './FilteredEventTile';
import { EmojiFrown } from 'react-bootstrap-icons';


export default observer( function CategoryPage() {
    const {t } = useTranslation()
    const { categoryPageStore: {
        events,
        loadEvents } } = useStore()

    useEffect(() => {
        loadEvents()
    }, [])

    return (
        <>
            <Container className="p-5" fluid >
                <>
                    <FilterForm />
                    {events.length === 0 ?
                        <Row className="border rounded shadow my-4">
                            <Col xs={12} className="p-3 text-center">
                                <p className="h3 p-4"><EmojiFrown className="mb-2 me-2" />Nie znaleziono wydarzeń spełniających Twoje kryteria.</p>
                            </Col>
                        </Row>
                        :
                        events.map(event =>
                            <FilteredEventTile key={event.id} event={event} />
                        )
                    }
                </>
            </Container>
        </>
    )
})