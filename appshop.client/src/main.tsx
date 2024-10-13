import { BrowserRouter } from 'react-router-dom';
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App'

import 'bootstrap/dist/css/bootstrap.min.css'

import { Provider } from 'react-redux'
import store from './redux/Store'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <Provider store={store}>
            <BrowserRouter>
                <App />
            </BrowserRouter>
        </Provider>
  </StrictMode >
  ,
)