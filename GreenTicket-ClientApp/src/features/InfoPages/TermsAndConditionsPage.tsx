import React from 'react';
import { Col, Container, ListGroup, Row } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { loremIpsum } from 'react-lorem-ipsum';

export default function TermsAndConditionsPage() {
    const { t } = useTranslation();

    return (
        <>
            <Container className="p-5" fluid >
                <Row className="p-5 border rounded shadow my-4">
                    <Col xs={12} className="text-start">
                        <p className="h3 ps-2 pb-2 fw-bold">{t("TermsAndConditions")}</p>
                    </Col> 
                    <Col xs={12} className="text-start">
                        <ListGroup>
                            {loremIpsum({ p: 20, random: true }).map((text, index) => (
                                <ListGroup.Item className="p-4" key={index}>
                                    {`${index + 1}. ${text}`}
                                </ListGroup.Item>
                            ))}
                        </ListGroup>
                    </Col>
                </Row>
            </Container>
        </>
    )
}