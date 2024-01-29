import { store } from '../store/store';

const userStoragePrefix: string = `${store.userStore.user?.id}`

const LocalStorage = {
    set: (key: string, obj: Object) => localStorage.setItem(`${userStoragePrefix}-${key}`, JSON.stringify(obj)),
    get: (key: string) => {
        var retrievedObject = localStorage.getItem(`${userStoragePrefix}-${key}`)
        return retrievedObject ? JSON.parse(retrievedObject) : null;
    },
    remove: (key: string) => localStorage.removeItem(`${userStoragePrefix}-${key}`)
}

const Lang = {
    get: () => {
        const storageLang = localStorage.getItem(`langID`);
        const lang = storageLang ? storageLang.toLowerCase() : "en";
        return lang;
    }
}

const storage = {
    Lang,
    LocalStorage
}


export default storage;
