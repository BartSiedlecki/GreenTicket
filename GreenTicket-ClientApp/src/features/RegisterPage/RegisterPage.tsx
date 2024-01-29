import { Formik, FormikHelpers } from 'formik';
import React, { useEffect, useState } from 'react';
import { Button, Col, Container, Form, Row, Spinner } from 'react-bootstrap';
import { PersonAdd } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { toast } from 'react-toastify';
import agent from '../../app/API/agent';
import { Country } from '../../app/models/country';
import { RegisterUserDto } from '../../app/models/registerUserDto';
import { RegisterUserDtoValidator } from '../../app/models/validators/registerUserDtoValidator';
import RegistrationTipsList from './RegistrationTipsList';
import DatePicker, { registerLocale } from 'react-datepicker';
import { fixTimezoneForOnChangeCalendarEvent, fixTimezoneForSelectedCalendarDate } from '../Shared/dateTimeManipulation';
import storage from '../../app/store/storage';
import { pl, enGB, de } from "date-fns/locale";

export default function RegisterPage() {
    const { t } = useTranslation();
    const [validateOnChange, setValidateOnChange] = useState(false);
    const [apiErrors, setApiErrors] = useState(null);
    const [countries, setCountries] = useState<Country[]>([]);

    useEffect(() => {
        agent.Countries.getList()
            .then(response => setCountries(response));
    }, [])

    const initValues: RegisterUserDto = {
        email: "",
        password: "",
        repeatPassword: "",
        firstName: "",
        lastName: "",
        dateOfBirth: null,
        street: "",
        streetNo: "",
        postalCode: "",
        city: "",
        countryId: "PL"
    }

    function compareCountryByName(a:Country, b:Country) {
        if (t(a.name) < t(b.name)) {
            return -1;
        }
        if (t(a.name) > t(b.name)) {
            return 1;
        }
        return 0;
    }

    const handleRegisterUser = (user: RegisterUserDto, actions: FormikHelpers<RegisterUserDto>) => {
        agent.Accounts.register(user)
            .then(() => toast.success(t("RegisterSuccessfull")))
            .catch(err => setApiErrors(err))
            .finally(() => { actions.setSubmitting(false); actions.resetForm(); });
    }

    const lang = storage.Lang.get();
   
    const leftControlColumnClass = "mt-2 pe-md-3 pe-lg-4";
    const rightControlColumnClass = "mt-2 ps-md-3 ps-lg-4";

    registerLocale("pl", pl);
    registerLocale("en", enGB);
    registerLocale("de", de);

    return (
        <>
            <Container className="p-5" fluid >
                <Row>
                    <Col xs={12} xxl={10} className="mx-auto">
                        <Row>
                            <Col xs={12} className="pb-4 text-center">
                                <p className="h3">
                                    <span><PersonAdd style={{ fontSize: "1.3em" }} className="me-2 mb-2" />{t("RegisterUserTitle")}</span>
                                </p>
                            </Col>
                        </Row>
                        <Formik
                            initialValues={initValues}
                            validateOnChange={validateOnChange}
                            validateOnBlur={true}
                            validate={values => new RegisterUserDtoValidator().validate(values)}
                            onSubmit={(values, actions) => handleRegisterUser(values, actions) }
                        >
                            {({ values: registerData, setFieldValue, handleSubmit, isSubmitting, handleChange, errors, resetForm }) => (
                                <Form onSubmit={handleSubmit} autoComplete="off" className="" >
                                    <Row className="p-4 p-xxl-5 border rounded shadow my-4">
                                        <Col xs={12}>
                                            <Row>
                                                <Col xs={12} md={6} className={leftControlColumnClass}>
                                                    <Col xs={12}>
                                                        <Form.Label htmlFor="email">{t("EmailAddress")}:</Form.Label>
                                                        <Form.Control
                                                            id='email'
                                                            name='email'
                                                            type='text'
                                                            maxLength={50}
                                                            className={errors.email || apiErrors ? "is-invalid" : undefined}
                                                            value={registerData.email}
                                                            onChange={handleChange} />
                                                        <Form.Control.Feedback
                                                            type='invalid'
                                                            className="mt-0">{errors.email}
                                                        </Form.Control.Feedback>
                                                    </Col>
                                                    <Col xs={12} className="mt-2">
                                                        <Form.Label htmlFor="password">{t("Password")}:</Form.Label>
                                                        <Form.Control
                                                            id='password'
                                                            name='password'
                                                            type='password'
                                                            maxLength={50}
                                                            className={errors.password || apiErrors ? "is-invalid" : undefined}
                                                            value={registerData.password}
                                                            onChange={handleChange} />
                                                        <Form.Control.Feedback
                                                            type='invalid'
                                                            className="mt-0">
                                                            {errors.password}
                                                        </Form.Control.Feedback>
                                                    </Col>
                                                    <Col xs={12} className="mt-2">
                                                        <Form.Label htmlFor="repeatPassword">{t("RepeatPassword")}:</Form.Label>
                                                        <Form.Control
                                                            id='repeatPassword'
                                                            name='repeatPassword'
                                                            type='password'
                                                            maxLength={50}
                                                            className={errors.repeatPassword || apiErrors ? "is-invalid" : undefined}
                                                            value={registerData.repeatPassword}
                                                            onChange={handleChange} />
                                                        <Form.Control.Feedback
                                                            type='invalid'
                                                            className="mt-0">
                                                            {errors.repeatPassword}
                                                        </Form.Control.Feedback>
                                                    </Col>
                                                </Col>
                                                <Col xs={12} md={6} className="mt-3 pt-md-3 ps-md-3 ps-lg-5 border-md-start">
                                                    <RegistrationTipsList />
                                                </Col>
                                            </Row>
                                            
                                        </Col>
                                    </Row>
                                    <Row className="p-4 p-xxl-5 border rounded shadow my-4">
                                        <Col xs={12}>
                                            <Row>
                                                <Col xs={12} className="text-center mb-3">
                                                    <p className="h3">
                                                        {t("PersonalInformation")}:
                                                    </p>
                                                </Col>
                                                <Col xs={12} md={6} className={leftControlColumnClass} >
                                                    <Form.Label htmlFor="firstName">{t("FirstName")}:</Form.Label>
                                                    <Form.Control
                                                        id='firstName'
                                                        name='firstName'
                                                        type='text'
                                                        maxLength={50}
                                                        className={errors.firstName || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.firstName}
                                                        onChange={handleChange} />
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.firstName}
                                                    </Form.Control.Feedback>
                                                </Col>
                                                <Col xs={12} md={6} className={rightControlColumnClass} >
                                                    <Form.Label htmlFor="lastName">{t("LastName")}:</Form.Label>
                                                    <Form.Control
                                                        id='lastName'
                                                        name='lastName'
                                                        type='text'
                                                        maxLength={30}
                                                        className={errors.lastName || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.lastName}
                                                        onChange={handleChange} />
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.lastName}
                                                    </Form.Control.Feedback>
                                                </Col>
                                                <Col xs={12} md={6} className={leftControlColumnClass}>
                                                    <Form.Label htmlFor="dateOfBirth" className="required">{t('DateOfBirth')}:</Form.Label>
                                                    <DatePicker
                                                        name=" n"
                                                        className={!!errors.dateOfBirth ? "form-control is-invalid" : "form-control"}
                                                        selected={fixTimezoneForSelectedCalendarDate(registerData.dateOfBirth)}
                                                        onChange={(date: any) => setFieldValue('dateOfBirth', fixTimezoneForOnChangeCalendarEvent(date))}
                                                        todayButton={t('today')}
                                                        locale={lang}
                                                        dateFormat="dd.MM.yyyy"
                                                        autoComplete="off"
                                                    />
                                                    <div className="text-danger fs-14px mt-4px" >{errors.dateOfBirth}</div>
                                                </Col>
                                                <Col xs={12} md={6} className={rightControlColumnClass}>
                                                    <Form.Label htmlFor="street">{t("Street")}:</Form.Label>
                                                    <Form.Control
                                                        id='street'
                                                        name='street'
                                                        type='text'
                                                        maxLength={50}
                                                        className={errors.street || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.street}
                                                        onChange={handleChange} />
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.street}
                                                    </Form.Control.Feedback>
                                                </Col>
                                                <Col xs={12} md={6} className={leftControlColumnClass}>
                                                    <Form.Label htmlFor="streetNo">{t("StreetNo")}:</Form.Label>
                                                    <Form.Control
                                                        id='streetNo'
                                                        name='streetNo'
                                                        type='text'
                                                        maxLength={50}
                                                        className={errors.streetNo || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.streetNo}
                                                        onChange={handleChange} />
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.streetNo}
                                                    </Form.Control.Feedback>
                                                </Col>
                                                <Col xs={12} md={6} className={rightControlColumnClass}>
                                                    <Form.Label htmlFor="postalCode">{t("PostalCode")}:</Form.Label>
                                                    <Form.Control
                                                        id='postalCode'
                                                        name='postalCode'
                                                        type='text'
                                                        maxLength={50}
                                                        className={errors.postalCode || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.postalCode}
                                                        onChange={handleChange} />
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.postalCode}
                                                    </Form.Control.Feedback>
                                                </Col>
                                                <Col xs={12} md={6} className={leftControlColumnClass}>
                                                    <Form.Label htmlFor="city">{t("City")}:</Form.Label>
                                                    <Form.Control
                                                        id='city'
                                                        name='city'
                                                        type='text'
                                                        maxLength={50}
                                                        className={errors.city || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.city}
                                                        onChange={handleChange} />
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.city}
                                                    </Form.Control.Feedback>
                                                </Col>
                                                <Col xs={12} md={6} className={rightControlColumnClass}>
                                                    <Form.Label htmlFor="country">{t("Country")}:</Form.Label>
                                                    <Form.Select
                                                        id='country'
                                                        name='countryId'
                                                        className={errors.countryId || apiErrors ? "is-invalid" : undefined}
                                                        value={registerData.countryId}
                                                        onChange={handleChange}
                                                    >
                                                        {countries.sort(compareCountryByName).map((country, index) => (
                                                            <option key={index} value={country.id}>{t(country.name)}</option>
                                                        ))}
                                                    </Form.Select>
                                                    <Form.Control.Feedback
                                                        type='invalid'
                                                        className="mt-0">{errors.countryId}
                                                    </Form.Control.Feedback>
                                                </Col>
                                            </Row>

                                            <Row className="mt-5">
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
                                                        {isSubmitting ? t("Registering") : t("Register")}
                                                    </Button>
                                                    <Button variant='secondary' className="mx-1" type='reset' onClick={() => {
                                                        setApiErrors(null);
                                                        setValidateOnChange(false);
                                                        resetForm();
                                                    }} >{t("Clear")}</Button>
                                                </Col>
                                            </Row>
                                        </Col>
                                    </Row>
                                </Form>
                            )}
                        </Formik>
                    </Col>
                </Row>
            </Container>
        </>
    )
}