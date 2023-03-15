import { createContext, useContext } from "react";
import CategoryPageStore from "./categoryPageStore";
import EventPageStore from "./eventPageStore";
import MainStore from "./mainStore";

interface Store {
    mainStore: MainStore,
    eventPageStore: EventPageStore,
    categoryPageStore: CategoryPageStore
}

export const store: Store = {
    mainStore: new MainStore(),
    eventPageStore: new EventPageStore(),
    categoryPageStore: new CategoryPageStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}