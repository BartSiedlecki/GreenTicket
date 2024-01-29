import { createContext, useContext } from "react";
import BasketStore from "./basketStore";
import CategoryPageStore from "./categoryPageStore";
import EventPageStore from "./eventPageStore";
import MainStore from "./mainStore";
import { UserStore } from "./userStore";

interface Store {
    mainStore: MainStore,
    eventPageStore: EventPageStore,
    categoryPageStore: CategoryPageStore,
    userStore: UserStore,
    basketStore: BasketStore
}

export const store: Store = {
    mainStore: new MainStore(),
    eventPageStore: new EventPageStore(),
    categoryPageStore: new CategoryPageStore(),
    userStore: new UserStore(),
    basketStore: new BasketStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}