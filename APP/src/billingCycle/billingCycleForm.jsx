import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

class BillingCycleForm extends Component {
    componentWillMount() {
        this.props.liveFace.setState({
            hs: 'a'
        })
    }

    render() {
        return (
            <div>
               <form role="form">
                   <div className="box-body">

                   </div>
                   <div className="box-footer">
                       <button type="submit" className="btn btn-primary">Submit</button>
                   </div>
               </form> 
            </div>
        )
    }
}

//const mapDispatchToProps = dispatch =>  bindActionCreators({selectTab, showTabs}, dispatch)
//connect(null, mapDispatchToProps)
export default BillingCycleForm