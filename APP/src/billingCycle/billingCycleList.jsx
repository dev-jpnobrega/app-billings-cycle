import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { GetList } from './billingCycleAction'

class BillingCycleList extends Component {
    componentWillMount() {
        this.props.GetList();
    }

    render() {
        return (
            <div>
                <table>
                    <tr>
                        <th>Nome</th>
                        <th>Mês</th>
                        <th>Ano</th>
                    </tr>
                </table>
                <tbody>

                </tbody>
            </div>
        )
    }
}

const mapStateToProps = state => ({list: state.billingCycle.list}) 
const mapDispatchToProps = dispatch => bindActionCreators({GetList}, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleList)