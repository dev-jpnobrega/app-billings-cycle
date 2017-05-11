
import { createStore, applyMiddleware } from 'redux'
import promise from 'redux-promise'

import reducers from './reducers'

const devTools = window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()

export default applyMiddleware(promise)(createStore)(reducers, devTools)