import i18n from "i18next";
import { initReactI18next } from "react-i18next";

import translationEN from '../src/data/locales/en.json';
import translationPL from '../src/data/locales/pl.json';

const resources = {
    en: {
        translation: translationEN
    },
    pl: {
        translation: translationPL
    }
};

i18n
    .use(initReactI18next) 
    .init({
        resources,
        lng: localStorage.getItem("langID") || "en",
        fallbackLng: "en",
        interpolation: {
            escapeValue: false 
        }
    });

export default i18n;
