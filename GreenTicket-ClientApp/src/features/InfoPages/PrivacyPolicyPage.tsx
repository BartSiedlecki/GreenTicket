import React from 'react';
import { Accordion, Col, Container, Row } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import LoremIpsum, { loremIpsum } from 'react-lorem-ipsum';

export default function PrivacyPolicyPage() {
    const { t } = useTranslation();

    return (
        <>
            <Container className="p-5" fluid >
                <Row className="p-5 border rounded shadow my-4">
                    <Col xs={12} className="text-start">
                        <p className="h3 ps-2 pb-2 fw-bold">{t("PrivacyPolicy")}</p>
                    </Col>
                    <Col xs={12} className="text-start">
                        <Accordion defaultActiveKey="0">
                            {loremIpsum({ p: 20, avgWordsPerSentence: 15, avgSentencesPerParagraph: 20, random: true, startWithLoremIpsum: false  }).map((text, index) => (
                                <Accordion.Item eventKey={index.toString()} key={index}>
                                    <>
                                        <Accordion.Header>
                                            {loremIpsum({ p: 1, avgWordsPerSentence: 5, avgSentencesPerParagraph: 1, random: true, startWithLoremIpsum: false }).map(text => (
                                                <span className="text" key={text}>
                                                    {index + 1}. {text}
                                                </span>
                                            ))}
                                        </Accordion.Header>
                                        <Accordion.Body>
                                            {`${text}`}
                                        </Accordion.Body>
                                    </>
                                </Accordion.Item>
                            ))}
                        </Accordion>
                    </Col>
                </Row>
            </Container>
        </>
    )
}   