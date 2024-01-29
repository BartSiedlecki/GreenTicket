export const fixTimezoneForSelectedCalendarDate = (date: Date | null | undefined) => {
    if (date === null) {
        return null
    }
    if (date === undefined) {
        return undefined
    }

    if (date.getTime === undefined) {
        const dateFromLS = new Date(date);
        return new Date(dateFromLS.getTime() + (dateFromLS.getTimezoneOffset() * 60000));
    }

    return new Date(date.getTime() + (date.getTimezoneOffset() * 60000));
}

export const fixTimezoneForOnChangeCalendarEvent = (date: Date | null | undefined) => {
    if (date === null) {
        return null
    }
    if (date === undefined) {
        return undefined
    }
    if (date.getTime === undefined) {
        const dateFromLS = new Date(date);
        return new Date(dateFromLS.getTime() + (dateFromLS.getTimezoneOffset() * 60000));
    }


    return new Date(date.getTime() - (date.getTimezoneOffset() * 60000));
}

