import React from 'react'
import { Router, Route, Redirect, hashHistory } from 'react-router'

import DashBoard from '../dashBoard/dashBoard'
import BillingCycle from '../billingCycle/BillingCycle'

export default props => (
    <Router history={hashHistory} >
        <Route path='/' component={DashBoard} />
        <Route path='/billingCycles' component={BillingCycle} />
        <Redirect from='*' to='/' />
    </Router>
)