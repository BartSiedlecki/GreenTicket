import React from 'react';
import { Col, Row } from 'react-bootstrap';
import { EnvelopeAt, Facebook, Instagram, Telephone, Twitter, Whatsapp } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import customHistory from '../../..';
import { config } from '../../../config';
import logo60 from '../../../data/logo/logo60.png';


export default function Footer() {
    const logoImg = logo60;
    const { t } = useTranslation();

    return (
        <>
            <div>
                {/*<Container fluid className="px-2 px-lg-4 w-100">*/}
                <Row className="upper-footer w-100 mx-0 py-4">
                    <Col className="d-xs-none d-sm-block" sm={1} lg={1}></Col>
                    <Col xs={12} sm={11} md={10} xl={11} className="mx-auto">
                        <Row>
                            <Col xs={12} sm={6} md={3} className="text-center text-sm-start py-2">
                                <Row>
                                    <Col xs={12}>
                                        <span className="footer-category">Green ticket</span>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => customHistory.push("/partnership")}>{t("Partnership")}</a>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => customHistory.push("/terms-and-conditions")}>{t("TermsAndConditions")}</a>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => customHistory.push("/privacy-policy")}>{t("PrivacyPolicy")}</a>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => customHistory.push("/legal-notice")}>{t("LegalNotice")}</a>
                                    </Col>
                                </Row>
                            </Col>
                            <Col xs={12} sm={6} md={3} className="text-center text-sm-start py-2">
                                <Row>
                                    <Col xs={12}>
                                        <span className="footer-category">{t("HelpAndContact")}</span>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => console.log("click")}>{t("PaymentMethods")}</a>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => console.log("click")}>{t("DeliveryMethods")}</a>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" onClick={() => console.log("click")}>{t("ReturnPolicy")}</a>
                                    </Col>
                                </Row>
                            </Col>
                            <Col xs={12} sm={6} md={3} className="text-center text-sm-start py-2">
                                <Row>
                                    <Col xs={12}>
                                        <span className="footer-category">{t("Services")}</span>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" href={`tel:${config.contactPhone}`}>
                                            <Telephone className="mb-1" />
                                            <Whatsapp className="mb-1 mx-1" /> {config.contactPhone}
                                        </a>
                                    </Col>
                                    <Col xs={12}>
                                        <a className="link footer-link" href={`mailto: ${config.contactEmail}`} >
                                            <EnvelopeAt className="mb-1" /> {config.contactEmail}
                                        </a>
                                    </Col>
                                    <Col xs={12}>
                                        <span style={{ fontSize: 12, color: '#8e9999' }} >{t("MonFri")}: 10:00 - 16:00</span>
                                    </Col>
                                </Row>
                            </Col>
                            <Col xs={12} sm={6} md={3} className="text-center text-sm-start py-2">
                                <Row>
                                    <Col xs={12}>
                                        <span className="footer-category">{t("Community")}</span>
                                    </Col>
                                    <Col xs={12} className="mt-1">
                                        <a className="link footer-link" target="_blank" href={config.facebookAddress} >
                                            <Facebook width={30} height={30} className="mx-1" />
                                        </a>
                                        <a className="link footer-link" target="_blank" href={config.instagramAddress} >
                                            <Instagram width={30} height={30} className="mx-1" />
                                        </a>
                                        <a className="link footer-link" target="_blank" href={config.twitterAddress} >
                                            <Twitter width={30} height={30} className="mx-1" />
                                        </a>
                                    </Col>
                                </Row>
                            </Col>
                        </Row>
                    </Col>
                </Row>
                <Row className="bottom-footer w-100 mx-0 rounded-bottom">
                    <Col xs={12} className="text-center py-2">
                        <img src={logoImg} width={30} height={30} />
                        <strong className="ms-1 green-logo-color">Green Ticket</strong>
                    </Col>

                </Row>
            </div>
        </>
    )
}