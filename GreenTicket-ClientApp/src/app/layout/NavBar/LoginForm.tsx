import { Formik } from 'formik';
import React, { useState } from 'react';
import { Button, Col, Form, Spinner } from 'react-bootstrap';
import { EmojiFrown, PersonAdd } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import ValidationErrorList from '../../../features/Shared/ValidationErrorList';
import { UserLoginDtoValidator } from '../../models/validators/userLoginDtoValidator';
import { useStore } from '../../store/store';

export default function LoginForm() {
    const { t } = useTranslation()
    const [apiErrors, setApiErrors] = useState(null);
    const [validateOnChange, setValidateOnChange] = useState(false)
    const initValues = { login: '', password: '', error: null }
    const { userStore } = useStore();

    return (
        <>
            <Formik
                initialValues={initValues}
                validateOnChange={validateOnChange}
                validateOnBlur={true}
                validate={values => new UserLoginDtoValidator().validate(values)}
                onSubmit={(values) => userStore.login(values)
                    .catch(err => {
                        setValidateOnChange(true);
                        setApiErrors(err);
                    })}
            >
                {({ values: loginData, handleSubmit, isSubmitting, handleChange, errors, resetForm }) => (
                    <Form onSubmit={handleSubmit} autoComplete='off' className='row g-3'>
                        <Col xs={12}>
                            <Form.Label htmlFor="login">{t("EmailAddress")}:</Form.Label>
                            <Form.Control
                                id='login'
                                name='login'
                                type='text'
                                maxLength={50}
                                className={errors.login || apiErrors ? "is-invalid" : undefined}
                                value={loginData.login}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.login}</Form.Control.Feedback>
                        </Col>
                        <Col xs={12}>
                            <Form.Label htmlFor="password">{t("Password")}:</Form.Label>
                            <Form.Control
                                id='password'
                                name='password'
                                type='password'
                                maxLength={50}
                                className={errors.password || apiErrors ? "is-invalid" : undefined}
                                value={loginData.password}
                                onChange={handleChange} />
                            <Form.Control.Feedback type='invalid' className="mt-0">{errors.password}</Form.Control.Feedback>
                        </Col>
                        <Col xs={12} className='text-center'>
                            <Button
                                variant='success'
                                className="mx-1"
                                type='submit'
                                onClick={() => setValidateOnChange(true)}
                            >
                                {isSubmitting ? <Spinner
                                    as="span"
                                    animation="grow"
                                    size="sm"
                                    role="status"
                                    aria-hidden="true"
                                    className="me-1"
                                /> : null}
                                {isSubmitting ? t("Logging") : t("LogIn")}
                            </Button>
                            <Button variant='secondary' className="mx-1" type='reset' onClick={() => {
                                setApiErrors(null);
                                setValidateOnChange(false);
                                resetForm();
                            }} >{t("Clear")}</Button>
                        </Col>
                        <Col xs={12} className='text-center mt-0' style={{ minHeight: "20px" }}>
                            {apiErrors &&
                                <ValidationErrorList errorList={apiErrors} />}
                        </Col>
                        
                    </Form>
                )}
            </Formik>
        </>
    )
}