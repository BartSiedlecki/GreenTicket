import { observer } from 'mobx-react-lite';
import { useState } from 'react';
import { Button, Col, Container, NavDropdown, Row } from 'react-bootstrap';
import { BoxArrowInRight, EmojiFrown, Person, PersonAdd, XLg } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import customHistory from '../../..';
import { useStore } from '../../store/store';
import LoginForm from './LoginForm';
import ResetPasswordForm from './ResetPasswordForm';

interface Props {
    className: string
}

export default function LoginDropDown({ className }: Props) {
    const { t } = useTranslation();
    const [selectedForm, setSelectedForm] = useState("loginForm");
    const { userStore } = useStore();

    return (
        <>
            <NavDropdown
                id="user-nav-dropdown"
                autoClose="outside"
                className={className}
                title={<span>
                    <Person
                        height={26}
                        width={26}
                    />
                </span>
                }
            >
                <Container className="dropdown-menu-lg-start" style={{ minWidth: "330px" }}>
                    <Row>
                        <Col xs={12}>
                            {selectedForm === "loginForm" ?
                                <LoginForm />
                                :
                                <ResetPasswordForm />}
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={5} className='text-start'>
                            <span className="text-primary c-pointer"
                                onClick={() => { customHistory.push("/register") }}>
                                <PersonAdd
                                    style={{ fontSize: "1.2em" }}
                                    className="me-1 mb-1" />
                                {t("Register")}
                            </span>
                        </Col>
                        {selectedForm === "loginForm" ?
                            <Col xs={7} className='text-end'>
                                <span
                                    className="text-primary c-pointer"
                                    onClick={() => setSelectedForm("resetPasswordForm")}
                                >
                                    {t("ForgotPassword")}
                                </span>
                            </Col>
                            :
                            <Col xs={7} className='text-end'
                                onClick={() => { setSelectedForm("loginForm"); }}
                            >
                                <span className="text-primary c-pointer">
                                    <BoxArrowInRight
                                        style={{ fontSize: "1.2em" }}
                                        className="me-1 mb-1"
                                    />
                                    {t("LogIn")}
                                </span>
                            </Col>
                        }
                    </Row>
                </Container>
            </NavDropdown>
        </>
    )
}