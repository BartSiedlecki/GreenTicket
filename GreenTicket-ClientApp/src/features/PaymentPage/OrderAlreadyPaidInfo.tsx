import { Col, Row } from "react-bootstrap";
import { useTranslation } from "react-i18next";

export default function OrderAlreadyPaid() {
    const { t } = useTranslation();

    return (
        <Row className="border rounded shadow p-3">
            <Col xs={12} xl={9} className="text-left py-2">
                <p>{t("OrderAlreadyPaid")}</p>
            </Col>
        </Row>
    )
}