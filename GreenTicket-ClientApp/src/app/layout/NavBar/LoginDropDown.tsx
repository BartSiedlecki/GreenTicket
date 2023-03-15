import React from 'react';
import { NavDropdown } from 'react-bootstrap';
import { Person } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';

interface Props {
    className : string
}

export default function LoginDropDown({ className } : Props) {
    const { t } = useTranslation()

    return (
        <>
            <NavDropdown
                id="user-nav-dropdown"
                className={className}
                title={<span><Person
                    height={26}
                    width={26} /></span>}/*<label>{user?.name}</label>*/
            >
                <NavDropdown.Item>
                    {t("LogIn")}
                </NavDropdown.Item>
            </NavDropdown>
        </>
    )
}