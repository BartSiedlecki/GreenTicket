import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Button, Col, Row } from "react-bootstrap";
import { BagCheckFill, InfoCircle } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";
import { toast } from "react-toastify";
import customHistory from "../..";
import agent from "../../app/API/agent";
import { OrderCreateDto } from "../../app/models/orderCreateDto";
import { useStore } from "../../app/store/store";
import ConfirmModalPopup from "../Shared/ConfirmModalPopup";

interface Props {
    placedOrderID: string | undefined;
    setPlacedOrderID: (placedOrderID: string | undefined) => void;
}

export default observer(function BasketSummaryNavigateButtons({ placedOrderID, setPlacedOrderID } : Props) {
    const { t } = useTranslation();
    const { basketStore, userStore } = useStore();
    const { clearBasket } = basketStore;
    const { user } = userStore;

    const [confirmAbortOrderModalShown, setConfirmAbortOrderModalShown] = useState(false);

    const handleAbortOrder = () => {
        setConfirmAbortOrderModalShown(true);
    }

    const handleConfirmAbortOrder = () => {
        clearBasket();
        customHistory.push("/main");
    }

    const handlePlaceOrder = () => {
        const dto: OrderCreateDto = {
            userId: user?.id!,
            tickets: basketStore.tickets.map(t => ({ placeId: t.placeId, isStanding: t.isStanding }))
        }

        console.log(dto);

        agent.Orders.create(dto).then((response) => {
            clearBasket();
            setPlacedOrderID(response);
            toast.success(t("OrderPlacingOk"));
        })
            .catch((err) =>
                toast.error(t("OrderPlacingError")));
    }

    const handleGoToPayment = () => {

        customHistory.push(`/payment/${placedOrderID}`);
    }

    return (<>
        <Row className="border rounded shadow my-4">
            <Col xs={12}>

            </Col>
            {placedOrderID ? 
                <>
                    <Col xs={12} className="mt-5 pb-3 text-center">
                        <p className="fs103em fw-bold text-success"><BagCheckFill className="fs101em mb-1 me-2"/>{t("OrderPlacedInfo1")}</p>
                        <p className="fs103em">{t("OrderPlacedInfo2")}</p>
                    </Col>
                    <Col xs={12} className="p-3 text-center">
                        <Button variant="success lg" size="lg" onClick={handleGoToPayment}>{t("GoToPayment")}</Button>
                    </Col>
                    <Col xs={12} className="p-3 fs101em text-center">
                        <p><InfoCircle className="mb-1 me-2"/>{t("OrderPlacedInfo3")}</p>
                        <p><InfoCircle className="mb-1 me-2" />{t("OrderPlacedInfo4")}</p>
                    </Col>
                </>
                :
                <>
                    <Col xs={6} className="p-3 text-end">
                        <Button variant="danger" size="lg" onClick={handleAbortOrder}>{t("AbortOrder")}</Button>
                    </Col>
                    <Col xs={6} className="p-3 text-start">
                        <Button variant="success lg" size="lg" onClick={handlePlaceOrder}>{t("PlaceOrderAndGoPayment")}</Button>
                    </Col>
                </>
                }
        </Row>
        <ConfirmModalPopup
            show={confirmAbortOrderModalShown}
            setShow={setConfirmAbortOrderModalShown}
            title={`${t("AbortOrder")}`}
            message={t("AbortOrderConfirm")}
            cancelButtonText={t("No")}
            confirmButtonText={t("AbortOrder")}
            onConfirm={handleConfirmAbortOrder}
            confirmButtonColorVariant="danger"
        />
    </>);
});