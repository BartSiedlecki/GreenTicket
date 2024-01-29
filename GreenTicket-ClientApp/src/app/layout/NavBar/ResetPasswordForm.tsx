import { Formik } from 'formik';
import React, { useState } from 'react';
import { Button, Col, Form } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { ResetPasswordDtoValidator } from '../../models/validators/resetPasswordDtoValidator';
import { useStore } from '../../store/store';

export default function ResetPasswordForm() {
    const { t } = useTranslation();
    const initValues = { email: '' };
    const [validateOnChange, setValidateOnChange] = useState(false);
    const { userStore } = useStore();
    const [apiErrors, setApiErrors] = useState(null);

    return (
        <>
            <Formik
                initialValues={initValues}
                validateOnChange={validateOnChange}
                validateOnBlur={true}
                validate={values => new ResetPasswordDtoValidator().validate(values)}
                onSubmit={
                    (values) => console.log(values)

                    //(values) => userStore.login(values)
                    //.catch(err => {
                    //    setValidateOnChange(true);
                    //    setApiErrors(err);
                    //})
                }
            >
                {({values: loginData, handleSubmit, handleChange, errors}) => (
                    <Form onSubmit={handleSubmit} autoComplete="off" className="row g-3" >
                        <Col xs={12}>
                            <Form.Label htmlFor="email">E-mail:</Form.Label>
                            <Form.Control
                                id='email'
                                name='email'
                                type='text'
                                maxLength={50}
                                className={apiErrors ? "is-invalid" : undefined}
                                value={loginData.email}
                                onChange={handleChange} />
                            <Form.Control.Feedback
                                type='invalid'
                                className="mt-0">
                                {errors.email}
                            </Form.Control.Feedback>
                        </Col>
                        <Col xs={12} className='text-center mb-4'>
                            <Button
                                variant="success"
                                type="submit"
                                className="mx-1"
                            >{t("ResetPassword")}</Button>
                            <Button
                                variant="secondary"
                                type="reset"
                                className="mx-1"
                            >{t("Clear")}</Button>
                        </Col>
                    </Form>
                )}
            </Formik>
        </>
    )
}