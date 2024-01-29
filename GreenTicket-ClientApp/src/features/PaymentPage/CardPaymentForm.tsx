import { Formik } from "formik";
import { useState } from "react";
import { Button, Col, Form, InputGroup, Spinner } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { PaymentCardDto } from "../../app/models/paymentCardDto";
import { PaymentCardValidator } from "../../app/models/validators/paymentCardValidator";
import PaymentConfirmationModal from "../Shared/PaymentConfirmationModal";

interface Props {
    makePayment: (userRecognitionDetail: string) => void;
}

export default function CardPaymentForm({ makePayment }: Props) {
    const { t } = useTranslation();
    const [validateOnChange, setValidateOnChange] = useState(false)
    const initValues: PaymentCardDto = {
        cardNo: "",
        cardHolderName: "",
        expireMonth: "",
        expireYear: "",
        CVV: ""
    }
    const [paymentmodalVisible, setPaymentmodalVisible] = useState(false);
    const [userRecognitionDetail, setUserRecognitionDetail] = useState("");

    return <>
        <Formik
            initialValues={initValues}
            validateOnChange={validateOnChange}
            validateOnBlur={true}
            validate={values => new PaymentCardValidator().validate(values)}
            onSubmit={(values) => {

                const paymentDetails: string = values.cardNo.slice(-4);
                setUserRecognitionDetail(paymentDetails)
                setPaymentmodalVisible(true);

            }}
        >
            {({ values: blik, handleSubmit, isSubmitting, handleChange, errors, resetForm }) => (
                <Form onSubmit={handleSubmit} autoComplete='off' className='row g-3 text-start'>
                    <Col xs={12}>
                        <Form.Group>
                            <Form.Label htmlFor="cardNo" className="mb-1" >{t("CardNo")}:</Form.Label>
                            <Form.Control
                                id='cardNo'
                                name='cardNo'
                                type='cardNo'
                                maxLength={16}
                                className={errors.cardNo ? "is-invalid" : undefined}
                                value={blik.cardNo}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.cardNo}</Form.Control.Feedback>
                        </Form.Group>
                    </Col>
                    <Col xs={12}>
                        <Form.Group>
                            <Form.Label htmlFor="cardHolderName" className="mb-1" >{t("FullName")}:</Form.Label>
                            <Form.Control
                                id='cardHolderName'
                                name='cardHolderName'
                                type='cardHolderName'
                                maxLength={50}
                                className={errors.cardHolderName ? "is-invalid" : undefined}
                                value={blik.cardHolderName}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.cardHolderName}</Form.Control.Feedback>
                        </Form.Group>
                    </Col>
                    <Col xs={6}>
                        <Form.Group>
                            <Form.Label htmlFor="expireMonth" className="mb-1" >{t("ExpireMonth")}:</Form.Label>
                            <Form.Control
                                id='expireMonth'
                                name='expireMonth'
                                type='expireMonth'
                                maxLength={2}
                                inputMode='numeric'
                                className={errors.expireMonth ? "is-invalid" : undefined}
                                value={blik.expireMonth}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.expireMonth}</Form.Control.Feedback>
                        </Form.Group>
                    </Col>
                    <Col xs={6}>
                        <Form.Group>
                            <Form.Label htmlFor="expireYear" className="mb-1" >{t("ExpireYear")}:</Form.Label>
                            <Form.Control
                                id='expireYear'
                                name='expireYear'
                                type='expireYear'
                                inputMode='numeric'
                                maxLength={4}
                                className={errors.expireYear ? "is-invalid" : undefined}
                                value={blik.expireYear}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.expireYear}</Form.Control.Feedback>
                        </Form.Group>
                    </Col>
                    <Col xs={12}>
                        <Form.Group>
                            <Form.Label htmlFor="CVV" className="mb-1" >CVV:</Form.Label>
                            <Form.Control
                                id='CVV'
                                name='CVV'
                                type='CVV'
                                inputMode='numeric'
                                maxLength={3}
                                className={errors.CVV ? "is-invalid" : undefined}
                                value={blik.CVV}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.CVV}</Form.Control.Feedback>
                        </Form.Group>
                    </Col>
                    <Col className="text-center">
                        <Button
                            variant="success"
                            type='submit'
                            size="lg"
                            onClick={() => setValidateOnChange(true)}
                        >
                            {t("MakePayment")}
                        </Button>
                    </Col>
                </Form>
            )}
        </Formik>
        <PaymentConfirmationModal show={paymentmodalVisible} setShow={setPaymentmodalVisible} onConfirm={() => makePayment(userRecognitionDetail)} />
    </>
}