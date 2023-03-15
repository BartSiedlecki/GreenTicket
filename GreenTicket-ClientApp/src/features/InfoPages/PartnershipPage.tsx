import React from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { LoremIpsum } from "react-lorem-ipsum";

export default function PartnershipPage() {
    const {t } = useTranslation();

    return (
        <>
            <Container className="p-5" fluid >
                <Row className="p-5 border rounded shadow my-4">
                    <Col xs={12} className="text-start">
                        <p className="h3 ps-2 pb-2 fw-bold">{t("Partnership")}</p>
                    </Col>
                    <LoremIpsum
                        p={10}
                        avgWordsPerSentence={6}
                        avgSentencesPerParagraph={11}
                    />

                    <LoremIpsum
                        p={4}
                        avgWordsPerSentence={7}
                        avgSentencesPerParagraph={9}
                    />
                    <Col xs={12} className="text-start">
                        <p className="h6 pe-5 pt-3 fw-bold text-end">Green Ticket</p>
                    </Col>
                </Row>

            </Container>
        </>
    )
}