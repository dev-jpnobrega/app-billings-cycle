import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { getList, showUpdate, showDelete } from './billingCycleAction'

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
                <td>
                    <button className='btn btn-warning' onClick={() => this.props.showUpdate(bc)} >
                        <i className='fa fa-pencil'></i>
                    </button> 
                
                    <button className='btn btn-danger' onClick={() => this.props.showDelete(bc)}>
                        <i className='fa fa-trash-o'></i>
                    </button> 
                </td>
            </tr>
        ))
    }

    render() {    
       return (
            <div>
                <table className='table'>
                    <thead>
                        <tr>
                            <th className='table-actions'>Nome</th>
                            <th className='table-actions'>Mês</th>
                            <th className='table-actions'>Ano</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderRows()}
                    </tbody>
                </table>
            </div>
        )
    }
}

const mapStateToProps = state => ({list: state.billingCycle.list}) 
const mapDispatchToProps = dispatch => bindActionCreators({ getList, showUpdate, showDelete }, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleList)