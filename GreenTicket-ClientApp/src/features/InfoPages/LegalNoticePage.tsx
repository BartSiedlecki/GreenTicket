import React from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import { EnvelopeAt, Telephone } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { config } from '../../config';

export default function LegalNoticePage() {
    const { t } = useTranslation();

    return (
        <>
            <Container className="p-5" fluid >
                <Row className="p-5 border rounded shadow my-4">
                    <Col xs={12} className="text-start">
                        <p className="h3 ps-2 pb-2 fw-bold">{t("LegalNotice")}</p>
                    </Col>
                    <Col xs={12} className="text-start">
                        <p className="">{t("legalNoticeText1")}</p>
                    </Col>
                    <Col xs={12} className="text-start">
                        <p className="">{t("legalNoticeText2")}</p>
                    </Col>
                    <Col xs={12} className="text-start">
                        <p className="">{t("legalNoticeText3")}</p>
                    </Col>
                    <Col xs={12} className="text-start">
                        <p className="fw-bold mb-1">Green Ticket Sp. z o.o.</p>
                        <span>{t("addressStreet")}<br/></span>
                        <span>{t("addressCity")}<br/></span>
                        <span>KRS: 00123123123 <br/></span>
                        <span>NIP: 00321321321 <br/></span>
                        <p className="fw-bold mt-4 mb-1">{t("Contact")}</p>
                        <span><Telephone className="mb-1 me-2" />{config.contactPhone} <br/></span>
                        <span><EnvelopeAt className="mb-1 me-2" /><a className="link" href={`mailto: ${config.contactEmail}`} >
                             {config.contactEmail}
                        </a></span>
                    </Col>
                </Row>
            </Container>
        </>
    )
}