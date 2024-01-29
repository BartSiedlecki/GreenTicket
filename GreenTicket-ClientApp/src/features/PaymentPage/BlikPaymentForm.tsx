import { Formik } from "formik";
import { useState } from "react";
import { Button, Col, Form, InputGroup, Spinner } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { BlikCodeDto } from "../../app/models/blikCodeDto";
import { BlikCodeValidator } from "../../app/models/validators/blikCodeValidator";
import PaymentConfirmationModal from "../Shared/PaymentConfirmationModal";

interface Props {
    makePayment: (userRecognitionDetail: string) => void;
}

export default function BlikPaymentForm({ makePayment }:Props) {
    const {t} = useTranslation(); 
    const [validateOnChange, setValidateOnChange] = useState(false)
    const initValues: BlikCodeDto = { code: ''}
    const [paymentmodalVisible, setPaymentmodalVisible] = useState(false);



    return <>
        <Formik
            initialValues={initValues}
            validateOnChange={validateOnChange}
            validateOnBlur={true}
            validate={values => new BlikCodeValidator().validate(values)}
            onSubmit={(values) => {

                setPaymentmodalVisible(true);

            }}
        >
            {({ values: blik, handleSubmit, isSubmitting, handleChange, errors, resetForm }) => (
                <Form onSubmit={handleSubmit} autoComplete='off' className='row g-3'>
                    <Col xs={6}>

                        <Form.Control
                            id='code'
                            name='code'
                            type='code'
                            maxLength={50}
                            className={errors.code ? "is-invalid" : undefined}
                            size="lg"
                                value={blik.code}
                                placeholder={`${t("BlikCode") }`}
                            onChange={handleChange} />
                        <Form.Control.Feedback type='invalid' className="mt-0">{errors.code}</Form.Control.Feedback>

                    </Col>
                    <Col>
                        <Button
                            variant="dark"
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
        <PaymentConfirmationModal show={paymentmodalVisible} setShow={setPaymentmodalVisible} onConfirm={() => makePayment("blik")} />
    </>
}