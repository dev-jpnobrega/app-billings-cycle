import React from 'react'
import ReactDom from 'react-dom'
import { Provider } from 'react-redux'

import App from './main/app'
import Store from './main/store'

ReactDom.render(
    <Provider store={Store}>        
        <App/>
    </Provider>, 
    document.getElementById('app')
)