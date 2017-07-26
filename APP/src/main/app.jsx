import React from 'react'

import Header  from '../common/template/header'
import SideBar from '../common/template/sidebar'
import Footer  from '../common/template/footer'
import Messagers from '../common/msg/messages'

export default props => (
    <div className="wrapper">
        <Header />
        <SideBar />
        <div className="content-wrapper">
            {props.children}
        </div>
        <Footer />
        <Messagers />
    </div>
)