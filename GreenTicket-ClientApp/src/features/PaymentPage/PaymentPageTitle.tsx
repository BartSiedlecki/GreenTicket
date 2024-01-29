import { Col, ListGroup, Row } from "react-bootstrap";
import { CurrencyExchange, InfoCircle } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";

export default function PaymentPageTitle() {
    const {t } = useTranslation();
    const infoIcon: JSX.Element = <InfoCircle className="mb-1" />

    return (
        <Row className="border rounded shadow p-3">
            <Col xs={12} xl={9} className="text-left py-2">
                <ListGroup variant="flush" className="text-secondary">
                    <ListGroup.Item className="fs103em text-secondary">{infoIcon} {t("*basketMakeSureText5")}</ListGroup.Item>
                    <ListGroup.Item className="fs103em text-secondary">{infoIcon} {t("*basketMakeSureText6")}</ListGroup.Item>
                    <ListGroup.Item className="fs103em text-secondary">{infoIcon} {t("*basketMakeSureText7")}</ListGroup.Item>
                </ListGroup>
            </Col>
            <Col xl={3} className="d-none d-xl-block h1 text-center" style={{ fontSize: "12em", color: "lightgray" }} >
                <CurrencyExchange />
            </Col>
        </Row>
    )
}