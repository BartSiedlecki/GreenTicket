import { Col, ListGroup, Row } from "react-bootstrap";
import { Cart4, InfoCircle } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";

export default function BasketPageTitle() {
    const { t } = useTranslation();


    const infoIcon: JSX.Element = <InfoCircle className="mb-1"/>
    const listGroupClass: string = "fs103em text-secondary"

    return (
        <Row className="border rounded shadow p-3">
            <Col xs={12} xl={9} className="text-left py-2">
                <ListGroup variant="flush" className="text-secondary">
                    <ListGroup.Item className={listGroupClass}>{infoIcon} {t("*basketMakeSureText1")}</ListGroup.Item>
                    <ListGroup.Item className={listGroupClass}>{infoIcon} {t("*basketMakeSureText2")}</ListGroup.Item>
                    <ListGroup.Item className={listGroupClass}>{infoIcon} {t("*basketMakeSureText3")}</ListGroup.Item>
                    <ListGroup.Item className={listGroupClass}>{infoIcon} {t("*basketMakeSureText4")}</ListGroup.Item>
                </ListGroup>
            </Col>
            <Col xl={3} className="d-none d-xl-block h1 text-center" style={{ fontSize: "12em", color: "lightgray" }} >
                <Cart4 />
            </Col>
        </Row>
    )
}