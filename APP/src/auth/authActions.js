import axios from 'axios'
import { toastr } from 'react-redux-toastr'
import Consts from '../consts'

const url_oapi = 'http://localhost:3003/oapi'

function submit(values, url) {
    return dispatch => {
        axios.post(url, values)
            .then(resp => {
                dispatch([
                    { type: 'USER_FETCHED', payload: resp.data }
                ])
            })
            .catch(e => {
                e.response.data.errors.forEach(erro => toastr.error('ERROR', erro))
            })
    }
}

export function login(values) {
    return submit(values, url_oapi + '/login')
}

export function signup(values) {
    return submit(values, url_oapi + '/signup')
}

export function logout() {
    return { type: 'TOKEN_VALIDATED', payload: false }
}

export function validateToken(token) {
    return dispatch => {
        if (token) {
            axios.post(url_oapi + '/validateToke', { token })
                .then(resp => {
                    dispatch({ type: 'TOKEN_VALIDATED', payload: resp.data.valid })
                })
                .catch(e => dispatch({ 
                    type: 'TOKEN_VALIDATED', payload: false 
                }))
        } else {
            dispatch({ type: 'TOKEN_VALIDATED', payload: false })
        }
    }
}


