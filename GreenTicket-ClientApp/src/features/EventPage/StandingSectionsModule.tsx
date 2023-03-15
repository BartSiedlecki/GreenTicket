import { observer } from 'mobx-react-lite';
import React from 'react';
import { Col, Form, Row } from 'react-bootstrap';
import { DashSquare, PlusSquare } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { SectionDto } from '../../app/models/sectionDto';
import { useStore } from '../../app/store/store';
import AddingTicktsModule from './AddinfTicketsModule';

interface Props {
    sections: SectionDto[]
}

export default observer(function StandingSectionsModule({ sections }: Props) {
    const { t } = useTranslation();
    const { eventPageStore } = useStore();

    return (
        <>
            <p className="h3">{t("StandingTickets")}:</p>
            {sections.map((section, index) => (
                <Row key={section.id} className="border rounded mb-4">
                    <Col xs={8}>
                        <p className="mb-0 p-3 pt-4 h4">{index + 1}. {section.name} ({section.price} zł)</p>
                    </Col>
                    <Col xs={4} className="text-end">
                        <p className="mb-0 p-3 pt-4 h4">
                            <AddingTicktsModule sectionId={section.id} sectionPrice={section.price} sectionName={section.name} />
                        </p>
                    </Col>
                </Row>
            ))}
        </>
    )
})