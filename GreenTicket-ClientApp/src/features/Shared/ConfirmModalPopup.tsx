import { Button, Modal } from "react-bootstrap";
import { QuestionCircle } from "react-bootstrap-icons";

interface Props {
    show: boolean,
    setShow: (show: boolean) => void;
    title: string,
    message: string,
    cancelButtonText: string,
    confirmButtonText: string,
    confirmButtonColorVariant?: string,
    onConfirm: () => void;
}

export default function ConfirmModalPopup({ show, setShow, title, message, confirmButtonText, confirmButtonColorVariant = "secondary", cancelButtonText, onConfirm }: Props) {

    const handleClose = () => setShow(false);

    return (
        <Modal show={show} onHide={handleClose} centered>
                <Modal.Header closeButton>
                <Modal.Title><QuestionCircle className="mb-2"/> {title}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                <h5 className="p-3 text-center fs101em">
                        {message}
                    </h5>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        {cancelButtonText}
                    </Button>
                <Button variant={confirmButtonColorVariant} onClick={onConfirm}>
                        {confirmButtonText}
                    </Button>
                </Modal.Footer>
            </Modal>
    );
}