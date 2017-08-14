import React from 'react'
import ReactDom from 'react-dom'
import { Provider } from 'react-redux'

import Routers from './main/routers'
import Store from './main/store'

ReactDom.render(
    <Provider store={Store}>        
        <Routers />
    </Provider>, 
    document.getElementById('app')
)