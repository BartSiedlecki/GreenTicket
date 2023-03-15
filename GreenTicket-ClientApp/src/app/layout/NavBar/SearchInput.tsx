import React, { useState } from 'react';
import moment from 'moment';
import { AsyncTypeahead } from "react-bootstrap-typeahead";
import agent from '../../API/agent';
import { EventNavigationSearchResultItemDto } from '../../models/eventNavigationSearchResultItemDto';
import { useTranslation } from 'react-i18next';
import { prepareRoutingParamText } from '../../../features/Shared/helpers';
import customHistory from '../../..';

export function SearchInput() {
    const { t } = useTranslation();

    const [isLoading, setIsLoading] = useState(false);
    const [options, setOptions] = useState<EventNavigationSearchResultItemDto[]>([]);

    const handleSearch = (query: string) => {

        agent.Events.navigationSearch(query)
            .then(response => {
                setOptions(response);
            })
    };

    const filterBy = () => true;

    const handleBuyTicketsButtonClick = (id: number, name: string, city: string) => {

        const paramEventText = prepareRoutingParamText(name);
        const paramCityText = prepareRoutingParamText(city);

        customHistory.push(`/event/${paramEventText}/${paramCityText}/${id}`);
    }

    return (
        <AsyncTypeahead
            className="nav-search"
            filterBy={filterBy}
            id="async-example"
            isLoading={isLoading}
            labelKey="name"
            highlightOnlyResult={true}
            minLength={3}
            onSearch={handleSearch}
            options={options}
            placeholder={t("SearchPlaceholderText") || ""}
            renderMenuItemChildren={(option: any) => (
                <>
                    <span
                        onClick={() => handleBuyTicketsButtonClick(option.id, option.name, option.city)}>{option.name}, {option.venueName}, {option.city} ({moment(new Date(option.startDateTime)).format("DD.MM.YYYY HH:mm")})</span>
                </>
            )}
        />
    )


}