import React, { useState } from 'react';
import { Formik, FormikHelpers } from 'formik';
import { Form, Col, Row, Button, Spinner } from 'react-bootstrap';
import { NewsletterFormModel } from '../../app/models/newsletterFormModel';
import NewsletterFormModelValidator from '../../app/models/validators/newsletterFormModelValidator';
import { useTranslation } from 'react-i18next';

export default function MainPageNewsletter() {
    const [validateOnChange, setValidateOnChange] = useState(false);
    const { t } = useTranslation();


    const initValues: NewsletterFormModel = {
        email: '',
        agreement: false
    };

    const handleSubmit = (val: NewsletterFormModel, actions: FormikHelpers<NewsletterFormModel>) => {

    }

    return (
        <>
            <div className="py-4">
                <Row className="">
                    <Col xs={10} className="mx-auto text-center rounded bg-white shadow dark-font border p-4 text-white">
                        <Row>
                            <Col>
                                <p className="mb-1 fw-bold" style={{ fontSize: '1.3em' }}>
                                    {t("NewsletterText#1")}
                                </p>
                                <p className="mb-2">
                                    {t("NewsletterText#2")}
                                </p>
                            </Col>
                        </Row>
                        <Row>
                            <Formik
                                enableReinitialize
                                initialValues={initValues}
                                validate={formValues => new NewsletterFormModelValidator().validate(formValues)}
                                onSubmit={(val, actions) => handleSubmit(val, actions)}
                                validateOnBlur={true}
                                validateOnChange={validateOnChange}
                            >
                                {({ values: newsletterData, handleChange, handleSubmit, errors, resetForm }) => (
                                    <Form>
                                        <Row>
                                            <Col xs={12} lg={10} xl={8} xxl={6} className="mx-auto">
                                                <Row>
                                                    <Col xs={8} >
                                                        <Form.Control
                                                            type="text"
                                                            id="email"
                                                            name="email"
                                                            maxLength={50}
                                                            value={newsletterData.email}
                                                            isInvalid={!!errors.email}
                                                            onChange={handleChange}
                                                            placeholder={t("EmailAddress") || ""}
                                                        />
                                                    </Col>
                                                    <Col xs={4} className="text-start">
                                                        <Button
                                                            className="mx-1"
                                                            type="submit"
                                                            onClick={(e) => { e.preventDefault(); setValidateOnChange(true); handleSubmit(); }}
                                                        >
                                                            {t("SignUp")}
                                                        </Button>
                                                    </Col>
                                                </Row>
                                                <Row>
                                                    <Col className="text-start mt-2" style={{ fontSize: "0.8em" }}>
                                                        <Form.Check
                                                            type="checkbox"
                                                            id="agreement"
                                                            name="agreement"
                                                            label={t("NewsletterText#3")}
                                                            className="mb-2"
                                                            isInvalid={!!errors.agreement}
                                                            onChange={handleChange}
                                                            checked={newsletterData.agreement}
                                                        />
                                                    </Col>
                                                </Row>
                                            </Col>
                                        </Row>
                                    </Form>
                                )}
                            </Formik>
                        </Row>
                    </Col>
                </Row>
            </div>
        </>
    )
}