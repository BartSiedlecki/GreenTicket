import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Col, Container, Row } from "react-bootstrap";
import { Cart2, InfoCircle } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";
import LoginForm from "../../app/layout/NavBar/LoginForm";
import { useStore } from "../../app/store/store";
import BasketPageTitle from "../BasketDropDown/BasketPageTitle";
import BasketReservationSummary from "./BasketReservationSummary";
import BasketSummaryNavigateButtons from "./BasketSummaryNavigateButtons";
import BasketUserDetailsSumarry from "./BasketUserDetailsSummary";

export default observer(function BasketPage() {
    const { t } = useTranslation();
    const { basketStore, userStore } = useStore();
    const { isBasketEmpty } = basketStore;
    const { user } = userStore;

    const [placedOrderID, setPlacedOrderID] = useState<string | undefined>(undefined);

    return <>
        <Container className="p-5" fluid >
            {isBasketEmpty() && !placedOrderID ?
                <Row className="border rounded shadow my-4">
                    <Col xs={12} className="p-3 text-center">
                        <Cart2 className="m-4 text-secondary" style={{ fontSize: "5em" }} />
                        <p className="h4">{t("EmptyBasket")} - <Link style={{ textDecoration: "none" }} to="/main">{t("ReturnToHomePage")}</Link>!</p>
                    </Col>
                </Row>
                :
                user ?
                    <>
                        <BasketPageTitle />
                        <BasketReservationSummary />
                        <BasketUserDetailsSumarry />
                        <BasketSummaryNavigateButtons placedOrderID={placedOrderID} setPlacedOrderID={setPlacedOrderID} />
                    </>
                    :
                    <Col xs={12} xl={6} className="mx-auto">
                        <Row className="border rounded shadow my-4 p-4">
                            <Col xs={12} className="p-3 text-center">
                                <InfoCircle className="m-4 text-secondary" style={{ fontSize: "5em" }} />
                                <p className="h4">{t("LoginRequiredBasketInfo")} <Link style={{ textDecoration: "none" }} to="/register">{t("ClickHereToRegister")}</Link>!</p>
                            </Col>
                            <Col xs={12} md={8} lg={6} className="mx-auto text-left border rounded p-3 mt-3 mb-5">
                                <Row>
                                    <LoginForm />
                                </Row>
                            </Col>
                        </Row>
                    </Col>
            }
        </Container>
    </>
})