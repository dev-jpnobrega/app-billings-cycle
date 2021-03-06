import axios from 'axios'
import { toastr } from 'react-redux-toastr'
import { reset as resetForm, initialize } from 'redux-form'

import { selectTab, showTabs } from '../common/tab/tabActions'

const BASE_URL = 'http://localhost:3003/api/'
const INITIAL_VALUES = {credits: [{}], debits: [{}]}


export function getList() {
    const request = axios.get(BASE_URL + '/billingCycles')

    return {
        type: 'BILLING_CYCLES_FETCHED',
        payload: request
    }
}

export function create(values) {
    return submit(values, 'post')
}

export function update(values) {
    return submit(values, 'put')
}

export function remove(values) {
    return submit(values, 'delete')
} 

function submit(values, method) {
     return dispatch => {
        const id = values._id ? values._id : ''
        axios[method](BASE_URL + '/billingCycles/' + id, values)
            .then(resp => {
                toastr.success("Sucesso", "Operação feita com sucesso")

                dispatch(init())
            })
            .catch(e => {
                e.response.data.errors.forEach(erro => toastr.error('ERROR', erro))
            })
    }
}

export function showUpdate(bc) {  
    return [
        showTabs('tabUpdate'),
        selectTab('tabUpdate'),
        initialize('billingCycleForm', bc)
    ]
}

export function showDelete(bc) {  
    return [
        showTabs('tabDelete'),
        selectTab('tabDelete'),
        initialize('billingCycleForm', bc)
    ]
}

export function init() {
    return [
        showTabs('tabList', 'tabCreate'),
        selectTab('tabList'),        
        getList(),
        initialize('billingCycleForm', INITIAL_VALUES)
    ]
}

