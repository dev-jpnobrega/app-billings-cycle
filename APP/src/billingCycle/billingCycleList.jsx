import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { getList } from './billingCycleAction'

class BillingCycleList extends Component {
    componentWillMount() {
        this.props.getList();
    }

    renderRows() {     
        const bcs = this.props.list || []
        
        return bcs.map(bc => (
            <tr key={bc._id}>
                <td>{bc.name}</td>
                <td>{bc.month}</td>
                <td>{bc.year}</td>
            </tr>
        ))
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
                   {this.renderRows()}
                </tbody>
            </div>
        )
    }
}

const mapStateToProps = state => ({list: state.billingCycle.list}) 
const mapDispatchToProps = dispatch => bindActionCreators({ getList }, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleList)