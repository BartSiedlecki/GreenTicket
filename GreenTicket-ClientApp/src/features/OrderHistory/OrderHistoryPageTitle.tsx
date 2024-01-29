import { Col, Container, Row } from "react-bootstrap";
import { ClockHistory } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";

export default function OrderHistoryTitle() {
    const {t } = useTranslation();

    return (
        <>
            <Container className="p-2" fluid >
                    <>
                        <Row>
                            <Col xs={12}  >
                                <p className="h1 fw-bold text-secondary text-center"><ClockHistory className="me-2 mb-2" />{t("OrderHistory")}</p>
                            </Col>
                        </Row>
                    </>
            </Container>
        </>
    );
}