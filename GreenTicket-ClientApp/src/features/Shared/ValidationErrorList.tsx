import React from 'react';
import { ListGroup } from 'react-bootstrap';
import { ExclamationTriangle } from 'react-bootstrap-icons';
import { useTranslation } from 'react-i18next';

interface Props {
    errorList: string[]
}

export default function ValidationErrorList({ errorList }: Props) {
    const {t } = useTranslation();
   
    return (
        <ListGroup variant="flush">
            {errorList.map((error: string, i) => (
                <ListGroup.Item key={i} className="text-danger fw-bold text-center">
                    <span style={{ fontSize: 22 }}><ExclamationTriangle /></span>
                    <span className="ms-1">{t(error)}</span>
                </ListGroup.Item>
            ))}
        </ListGroup>
    )
}