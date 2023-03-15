import React, { useEffect, useState } from 'react';
import { EventCarousel } from './EventCarousel';
import MainCategory from './MainCategory';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/store/store';
import { Bank, CalendarPlus, Dribbble } from 'react-bootstrap-icons';
import MainPageNewsletter from './MainPageNewsletter';
import { useTranslation } from 'react-i18next';


export default observer(function MainPage() {
    const { t } = useTranslation();

    const { mainStore } = useStore();
    const { newestEvents, sportEvents, cultureEvents, loadMainEvents } = mainStore;

    useEffect(() => {
        loadMainEvents();
    }, []);

    return (
        <div>
            <EventCarousel />
            <MainCategory events={newestEvents} categoryName={t("New events")} icon={<CalendarPlus className="me-2 mb-1" />} />
            <MainCategory events={sportEvents} categoryName="Sport" icon={<Dribbble className="me-2 mb-1" />} />
            <MainCategory events={cultureEvents} categoryName={t("Culture")} icon={<Bank className="me-2 mb-1" />} />
            <MainPageNewsletter />
            <MainCategory events={cultureEvents} categoryName={t("Concerts")} icon={<Bank className="me-2 mb-1" />} />
        </div>
    )
})