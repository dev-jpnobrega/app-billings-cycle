
import { createStore, applyMiddleware } from 'redux'
import promise from 'redux-promise'
import thunk from 'redux-thunk'
import multi from 'redux-multi'


import reducers from './reducers'

const devTools = window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()

export default applyMiddleware(multi, thunk, promise)(createStore)(reducers, devTools)