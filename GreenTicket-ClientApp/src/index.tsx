import { createBrowserHistory } from 'history';
import React from 'react';
import ReactDOM from 'react-dom/client';
import { CustomRouter } from './app/customRouter/CustomRouter';
import App from './app/layout/App';
import './app/layout/style.css';
import { store, StoreContext } from './app/store/store';



const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

const customHistory = createBrowserHistory();
export default customHistory;

root.render(
    <StoreContext.Provider value={store}>
        <CustomRouter history={customHistory}>
            <App />
        </CustomRouter >
    </StoreContext.Provider>
);

