import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { GetList } from './billingCycleAction'

class BillingCycleList extends Component {
    componentWillMount() {
        this.props.GetList();
    }

    rendeRows(bcs) {
        const list = this.props.list || []
     
        console.log(list)
        return bcs.map(bc => (
            <tr key={bc._id}>
                <td>{bc.name}</td>
                <td>{bc.month}</td>
                <td>{bc.year}</td>
            </tr>
        ))
    }

    render() {
        console.log('RENDER')
        console.log(this.props.list)

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
                    {this.rendeRows(this.props.list)}     
                </tbody>
            </div>
        )
    }
}

const mapStateToProps = state => ({list: state.billingCycle.list}) 
const mapDispatchToProps = dispatch => bindActionCreators({GetList}, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleList)