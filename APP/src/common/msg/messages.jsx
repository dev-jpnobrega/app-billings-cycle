import React, { Component } from 'react'
import ReactToaster from 'react-redux-toastr'

import 'modules/react-redux-toastr/lib/css/react-redux-toastr.css'

export default props => (
    <ReactToaster 
        timeOut={4000}
        newestOnTop={false}
        preventDuplicate={true}
        transitionIn='bounceIn'
        transitionOut= 'bounceOut'
        position='top-right'
        progressBar  />
)