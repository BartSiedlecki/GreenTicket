import { useEffect, useState } from "react";
import { Col, Container, Form, ListGroup, Row } from "react-bootstrap";
import { InfoCircle, PersonCheck } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import agent from "../../app/API/agent";
import { BasketUserDetailsDto } from "../../app/models/basketUserDetailsDto";
import { Country } from "../../app/models/country";
import { useStore } from "../../app/store/store";

export default function BasketUserDetailsSumarry() {
    const { t } = useTranslation();
    const { userStore } = useStore();
    const { user } = userStore;

    const [userDetails, setUserDetails] = useState<BasketUserDetailsDto>();

    useEffect(() => {
        if (user) {
            agent.Users.details(user.id!, "basket")
                .then(response => { console.log(response);  setUserDetails(response); });
        }
    }, [user])

    const listLabelClass = "fw-bold"
    const infoIcon: JSX.Element = <InfoCircle className="mb-1 me-1" />

    return (
        <>
            <Row className="p-4 p-xxl-5 border rounded shadow my-4">
                <Col xs={12} className="pb-4 text-center">
                    <p className="h3">
                        <span><PersonCheck style={{ fontSize: "1.3em" }} className="me-2 mb-2" />{t("UserData")}</span>
                    </p>
                </Col>
                <Col xs={12} md={6}>
                    <ListGroup variant="flush">
                        <ListGroup.Item><span className={listLabelClass}>{t("EmailAddress")}</span>: {userDetails?.email}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("FirstName")}</span>: {userDetails?.firstName}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("LastName")}</span>: {userDetails?.lastName}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("Street")}</span>: {userDetails?.street}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("StreetNo")}</span>: {userDetails?.streetNo}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("PostalCode")}</span>: {userDetails?.postalCode}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("City")}</span>: {userDetails?.city}</ListGroup.Item>
                        <ListGroup.Item><span className={listLabelClass}>{t("Country")}</span>: {userDetails?.country}</ListGroup.Item>
                    </ListGroup>
                </Col>
                <Col xs={12} md={6} className="text-center">
                    <p className="p-5 fs103em">{infoIcon}{t("IfWantChangeData")} <Link style={{ textDecoration: "none" }} to="/profile">{t("GoToAccountSettings")}</Link></p>
                </Col>
            </Row>
        </>)
}

