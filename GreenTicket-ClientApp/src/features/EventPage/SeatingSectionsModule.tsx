import { observer } from 'mobx-react-lite';
import React, { ChangeEvent, useEffect, useState } from 'react';
import { Col, Form, Row } from 'react-bootstrap';
import { DashSquare, PlusSquare } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import agent from '../../app/API/agent';
import { SectionDto } from '../../app/models/sectionDto';
import { useStore } from '../../app/store/store';
import AddingTicktsModule from './AddingTicketsModule';
import Seat from './Seat';

interface Props {
    eventId: number,
    sections: SectionDto[]
}

export default observer(function SeatingSectionsModule({ eventId, sections }: Props) {
    const { t } = useTranslation();
    const { eventPageStore, basketStore } = useStore();
    const { selectedSection, setSelectedSection, loadSectionPreview } = eventPageStore;
    const { tickets } = basketStore;


    const [sectedSectionId, setSectedSectionId] = useState();

    const handleSelectChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const selectedId = Number(event.target.value);
        const section = sections.find(s => s.id === selectedId)

        if (section) {
            setSelectedSection(section);
            loadSectionPreview();
        }
    }



    useEffect(() => {
      console.log("----------------------")
        setSelectedSection(selectedSection);
        loadSectionPreview();
    }, [tickets])

    return (
        <>
            <p className="h3">{t("SeatingTickets")}:</p>
            <Row className="mx-0 my-2 px-0">
                <Col xs={12}>
                    <Form.Select size="lg"
                        onChange={(e) => handleSelectChange(e)}
                        value={sectedSectionId}
                    >
                        {sections.map(section => (
                            <option key={section.id} value={section.id} >{section.name} - {section.price} zł</option>
                        ))}
                    </Form.Select>
                </Col>
            </Row>
            <Row className="border rounded mb-4" style={{ maxHeight: "600px", overflowY: "auto", scrollbarGutter: "stable" }}>
                {selectedSection ?
                    <Row className="mx-0 my-2 px-0">
                        <Col xs={12} className="text-center">
                            <h4 className="fw-bold">{t("Section")}: {selectedSection.name} - {selectedSection.price} zł</h4>
                        </Col>
                        <Col xs={12}>
                            {selectedSection.rows.map((row, index) => (
                                <Row key={index} className="">
                                    <Col xs={1} className="text-end my-2">
                                        {row.name}
                                    </Col>
                                    <Col xs={10} className="seating-preview-row text-center my-0 px-0">
                                        {row.seats.map(seat => (
                                            <Seat key={seat.id} seat={seat} eventId={eventId} sectionId={selectedSection.id} sectionPrice={selectedSection.price} row={row}  />
                                        ))}
                                    </Col>
                                    <Col xs={1} className="my-2">
                                        {row.name}
                                    </Col>
                                </Row>
                            ))}
                        </Col>
                        <Col xs={12} className="text-center">
                            <h4 className="fw-bold">Section: {selectedSection.name} - {selectedSection.price} zł</h4>
                        </Col>
                    </Row>
                    : undefined}
            </Row>

        </>
    )
})
