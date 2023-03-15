import React from 'react';
import { NavDropdown } from 'react-bootstrap';
import { GlobeAmericas } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';
import { toast } from 'react-toastify';
import i18n from '../../../i18Next';

interface Props {
    className: string
}

export function LangDropDown({ className } : Props) {
    const { t } = useTranslation();

    const changeLang = (lang: string) => {
        localStorage.setItem('langID', lang);
        i18n.changeLanguage(lang);
        toast.info(t("LanguageChanged"))
    }

    return (
        <NavDropdown
            className={className}
            id="lang-nav-dropdown"
            title={
                <span><GlobeAmericas
                    height={26}
                    width={26} />
                    <label className="ms-2">{localStorage.getItem("langID")?.toUpperCase()}</label>
                </span>
            }
        >
            <NavDropdown.Item onClick={() => changeLang('pl')}>
                PL
            </NavDropdown.Item>
            <NavDropdown.Item onClick={() => changeLang('en')}>
                EN
            </NavDropdown.Item>
        </NavDropdown>
    )
}