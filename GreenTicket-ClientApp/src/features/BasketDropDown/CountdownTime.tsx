import { t } from 'i18next';
import { observer } from 'mobx-react-lite';
import moment from 'moment';
import React from 'react';
import { HourglassSplit } from 'react-bootstrap-icons';
import Countdown, { zeroPad, calcTimeDelta, formatTimeDelta } from 'react-countdown';
import { useStore } from '../../app/store/store';

interface Props {
    reservedTo: Date,
    placeId: string,
    onRemove: (placeID: string) => void;
}


export default observer(function CountdownTime({ reservedTo, placeId, onRemove }: Props) {
    let minutesLeft = moment.duration(moment(reservedTo).diff(moment())).minutes();

    const ramainingTimeColorCssClass = minutesLeft > 3 ? "text-success" : "text-danger"

    const Completionist = () => <span>
        <HourglassSplit className="mb-1 fw-bold" height={18} width={18} />
        {t("ReservationExpired")}
    </span>;

    const renderer = ({ hours, minutes, seconds, completed }: any) => {
        if (completed) {
            return <Completionist />;
        } else {
            return <span className={ramainingTimeColorCssClass}>{minutes}:{seconds}</span>;
        }
    };

    return (
        <Countdown
            date={reservedTo}
            className={ramainingTimeColorCssClass}
            renderer={renderer}
            zeroPadTime={3}
            onComplete={() => onRemove(placeId)}
        />
    )
})