import { useEffect, useState } from "react";
import { Button, Modal, Spinner } from "react-bootstrap";
import { HourglassSplit } from "react-bootstrap-icons";
import { useTranslation } from "react-i18next";
import { useStore } from "../../app/store/store";

interface Props {
    show: boolean,
    setShow: (show: boolean) => void;
    onConfirm: () => void;
}

export default function PaymentConfirmationModal({ show, setShow, onConfirm }: Props) {
    const { t } = useTranslation();
    const [processingType, setProcessingType] = useState<"waiting" | "processing">("waiting")

    useEffect(() => {
        if (show) {
            setTimeout(() => {
                setShow(false);
                onConfirm();
            }, 8000);

            setTimeout(() => {
                setProcessingType("processing")
            }, 4000);
        }
    }, [show]);

    return (
        <Modal show={show} onShow={() => setProcessingType("waiting")} centered>
            <Modal.Header closeButton>
                <Modal.Title><HourglassSplit className="mb-2" /> {t("ConfirmPayment")}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="p-4 text-center">
                    <Spinner style={{ width: "5rem", height: "5rem" }} animation="grow" variant="success" />
                </div>
                <h4 className="p-3 text-center">
                    {t("ProcesingPayment1")}
                </h4>
                <h5 className="p-3 text-center fw-bold">
                    {processingType === "waiting" ? t("ProcesingPayment2") : t("ProcesingPayment3")}
                </h5>
            </Modal.Body>
        </Modal>
    );
}