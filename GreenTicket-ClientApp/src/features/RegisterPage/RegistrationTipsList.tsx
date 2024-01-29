import React from 'react';
import { ListGroup } from 'react-bootstrap';
import { InfoCircle, InfoLg } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';

export default function RegistrationTipsList() {
    const { t } = useTranslation();
    const tips = [t("RegisterTip1"), t("RegisterTip2"), t("RegisterTip4")];

    return (
        <>
            <ListGroup variant="flush">
                {tips.map((tip, index) => (
                    <ListGroup.Item key={index}><InfoLg style={{ fontSize: "1.5rem" }} className="mb-1" />{tip}</ListGroup.Item>
                )) }

            </ListGroup>
        </>
    )
}