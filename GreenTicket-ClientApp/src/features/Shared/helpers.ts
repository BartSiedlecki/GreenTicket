export const prepareRoutingParamText = (text: string | undefined) => {
    if (text === undefined) {
        return "all"
    }

    let tmpText = replacePolishSigns(text);
    tmpText = removeSpecialSignsFromString(tmpText)
    tmpText = replaceSpacebarsWithDashes(tmpText)
    tmpText = tmpText.toLowerCase()
    return tmpText;
}

export function isNumeric(value: string | undefined) {
    if (value === undefined) {
        return false;
    }

    return /^\d+$/.test(value);
}

export function addLeadingZero(num: number) {
    return String(num).padStart(2, '0')
}

function replacePolishSigns(text: string) {
    const expression: RegExp = /[ąćęłńóśźż]/gi;

    const replacements: Record<string, string> = {
        'ą': 'a', 'ć': 'c', 'ę': 'e', 'ł': 'l', 'ń': 'n', 'ó': 'o', 'ś': 's', 'ź': 'z', 'ż': 'z',
        'Ą': 'A', 'Ć': 'C', 'Ę': 'E', 'Ł': 'L', 'Ń': 'N', 'Ó': 'O', 'Ś': 'S', 'Ź': 'Z', 'Ż': 'Z'
    };

    return text.replace(expression, (letter) => replacements[letter]);
}

function removeSpecialSignsFromString(text: string) {
    return text.replace(/[^a-z\d\s]+/gi, "");
}

function replaceSpacebarsWithDashes(text: string) {
    let tmpText = text.replace(/ /g, '-');
    tmpText = tmpText.replace(/--/g, '-');
    return tmpText;
}
